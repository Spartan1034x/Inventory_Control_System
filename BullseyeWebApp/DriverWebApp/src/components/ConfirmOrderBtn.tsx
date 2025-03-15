import { useDeliveries, DeliveryDTO } from "../contexts/DeliveryContext";
import { useVehicles } from "../contexts/VehicleContext";
import { useOrders } from "../contexts/OrdersContext";
import { createDelivery } from "../DatabaseOps";
import { useEffect, useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap/dist/js/bootstrap.bundle.min.js";
import { Tooltip } from "bootstrap";

function ConfirmButton({
	notes,
	setNotes,
}: {
	notes: string;
	setNotes: (value: string) => void;
}) {
	// The selected order in the dgv will have a delivery object created and the DeliveryID in the txn will be set to that delivery object's ID

	const { selectedVehicle } = useVehicles(); // Selected vehicle from the vehicles context

	const { orders, selectedOrder } = useOrders(); // Selected order(txn) from the orders context

	const { newDelivery, setNewDelivery } = useDeliveries(); // New delivery object and ftn from the delivery contextt

	// ADD TO DELIVERY FUNCTION
	const AddToDelivery = () => {
		// Ensure selectedOrder and selectedVehicle exist
		if (!selectedVehicle) {
			alert("Please select a vehicle first.");
			return;
		}

		if (!selectedOrder) {
			alert("Please select an order first.");
			return;
		}

		// Find the order in the orders array
		const matchingOrder = orders.find(
			(order) => order.txnId === selectedOrder.txnId
		);

		if (!matchingOrder) {
			alert("Error: Order not found. Try again.");
			return;
		}

		// If the selected vehicle is a courier and the order is not an emergency delivery, block selection
		if (
			selectedVehicle.vehicleType === "Courier" &&
			!matchingOrder.emergencyDelivery
		) {
			alert("Cannot add non-emergency order to courier.");
			return;
		}

		// Add selected Delivery to newDelivery
		setNewDelivery((prevDelivery) => {
			// If newDelivery is null, initialize it
			if (!prevDelivery) {
				return {
					txnIDs: [Number(selectedOrder.txnId)], // Start txn array
					vehicleType: selectedVehicle.vehicleType,
					maxWeight: selectedVehicle.maxWeight,
					currentWeight: selectedOrder.totalWeight, // Set initial weight
				};
			}

			// If the order is already in the delivery, block selection
			if (prevDelivery.txnIDs.includes(Number(selectedOrder.txnId))) {
				alert("Order already in delivery.");
				return prevDelivery;
			}

			// If the weight limit is exceeded, block selection
			if (
				prevDelivery.currentWeight + selectedOrder.totalWeight >
				prevDelivery.maxWeight
			) {
				alert(
					"Weight limit exceeded, select a larger truck to add this order."
				);
				return prevDelivery;
			}

			// If the order is not of status "ASSEMBLED", block selection
			if (matchingOrder.txnStatus !== "ASSEMBLED") {
				alert("Order must be of status 'ASSEMBLED' to add.");
				return prevDelivery;
			}

			return {
				...prevDelivery,
				txnIDs: [...prevDelivery.txnIDs, Number(selectedOrder.txnId)], // Append txnId
				currentWeight: prevDelivery.currentWeight + selectedOrder.totalWeight, // Add weight
			};
		});
	}; // END ADD TO DELIVERY FUNCTION

	// REMOVE FROM DELIVERY FUNCTION
	const RemoveFromDelivery = () => {
		// Make sure we have a current delivery and a selected order
		if (!newDelivery) {
			alert("There's no delivery to remove from.");
			return;
		}
		if (!selectedOrder) {
			alert("Please select an order to remove.");
			return;
		}

		// Check if the selected order is actually in the delivery
		if (!newDelivery.txnIDs.includes(Number(selectedOrder.txnId))) {
			alert("Order is not in the delivery.");
			return;
		}

		// Calculate the updated txnIDs array and new weight
		const updatedTxnIDs = newDelivery.txnIDs.filter(
			(id) => id !== Number(selectedOrder.txnId)
		);
		const updatedWeight = newDelivery.currentWeight - selectedOrder.totalWeight;

		// Update newDelivery with the removed order
		setNewDelivery((prevDelivery) => {
			if (!prevDelivery) return prevDelivery; // Safety check

			return {
				...prevDelivery,
				txnIDs: updatedTxnIDs,
				currentWeight: updatedWeight,
			};
		});
	}; // END REMOVE FROM DELIVERY FUNCTION

	// CONFIRM DELIVERY FUNCTION
	const ConfirmDelivery = () => {
		// Ensure newDelivery has at least one txnID in its array
		if (!newDelivery || newDelivery.txnIDs.length === 0) {
			alert("No orders in delivery.");
			return;
		}

		// Create new DeliveryDTO with array of txnIDs and vehicleType
		const deliveryDTO: DeliveryDTO = {
			deliveryID: 0, // DeliveryID is set by the database
			txnIDs: newDelivery.txnIDs,
			vehicleType: newDelivery.vehicleType,
			emergencyOrder: newDelivery.vehicleType === "Courier" ? true : false,
			totalWeight: newDelivery.currentWeight,
			deliveryDate: new Date().toISOString(),
			notes: notes,
		};

		// Send the new delivery to the database
		createDelivery(deliveryDTO)
			.then(() => {
				alert("Delivery confirmed.");
				setNewDelivery(null); // Reset newDelivery
				console.log("Delivery confirmed:", Response);
			})
			.catch((error) => {
				console.error("Failed to confirm delivery:", error);
				alert("Failed to confirm delivery.");
			});
	}; // END CONFIRM DELIVERY FUNCTION

	//  DISABLED FUNCTION
	// Function to match sent in date vs todays date, returns true if dates match
	const isToday = (date: Date) => {
		const today = new Date();
		return (
			date.getDate() === today.getDate() &&
			date.getMonth() === today.getMonth() &&
			date.getFullYear() === today.getFullYear()
		);
	};

	// Changes the disabled state of the button based on if selected order is today
	/*useEffect(() => {
		if (selectedOrder && !isToday(new Date(selectedOrder.shipDate))) {
			CanSubmitOrderButton(true);
			alert("Order is not scheduled for today, cannot add to delivery.");
		} else {
			CanSubmitOrderButton(false);
		}
	}, [selectedOrder]);

	const [isDisabled, setIsDisabled] = useState(false);

	const CanSubmitOrderButton = (disabled: boolean) => {
		setIsDisabled(disabled);
	}; */

	const isDisabled = false; // Delete for use of useEffect

	return (
		<div className="row d-flex justify-content-center m-5">
			<div className="col d-flex justify-content-center gap-5">
				<button
					className="btn btn-primary"
					onClick={AddToDelivery}
					title="Can only add orders scheduled for today"
					disabled={!selectedOrder || isDisabled}>
					Add To Delivery
				</button>
				<button
					className="btn btn-danger"
					disabled={!newDelivery?.txnIDs.includes(Number(selectedOrder?.txnId))}
					onClick={RemoveFromDelivery}>
					Remove From Delivery
				</button>
				<button
					className="btn btn-success"
					disabled={!newDelivery || newDelivery.txnIDs.length === 0}
					onClick={ConfirmDelivery}>
					Confirm Delivery
				</button>
			</div>{" "}
		</div>
	);
}

export default ConfirmButton;
