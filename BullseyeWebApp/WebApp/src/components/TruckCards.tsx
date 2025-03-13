import { useDeliveries } from "../contexts/DeliveryContext";
import { useVehicles } from "../contexts/VehicleContext";
import { useOrders } from "../contexts/OrdersContext";
import { useEffect, useCallback } from "react";
import React from "react";

function TruckDisplay() {
	const { vehicles, selectedVehicle, setSelectedVehicle } = useVehicles();
	const { newDelivery, setNewDelivery } = useDeliveries();
	const { orders } = useOrders();

	// Log vehicles
	/* useEffect(() => {
		console.log(vehicles);
	}, [vehicles]); */

	const firstRender = React.useRef(true);

	// Whenever selected Vehicle changes log, and call ftn to update delivery vehicle in the delivery context
	useEffect(() => {
		// console.log(selectedVehicle);

		// If this is the first render, return
		if (firstRender.current) {
			firstRender.current = false;
			return;
		}

		if (!selectedVehicle) return;

		updateDeliveryVehicle(
			selectedVehicle.vehicleType,
			selectedVehicle.maxWeight
		);
	}, [selectedVehicle]);

	const handleSelectVehicle = (vehicle) => {
		// If there is an active delivery and the vehicle cannot carry the weight, block selection
		if (newDelivery && newDelivery.currentWeight > vehicle.maxWeight) {
			alert("Cannot select this truck, weight limit exceeded.");
			return;
		}

		// Search all orders in the delivery to check if there is a non emergency order
		const deliveryOrders = orders.filter((order) =>
			newDelivery?.txnIDs.includes(order.txnId)
		);

		const hasRegularOrder = deliveryOrders.some(
			(order) => !order.emergencyDelivery
		);

		// If the vehicle is a courier and the delivery contains a non emergency order, block selection
		if (vehicle.vehicleType === "Courier" && hasRegularOrder) {
			alert("Cannot select this truck, non-emergency order in delivery.");
			return;
		}

		// Otherwise, allow vehicle selection
		setSelectedVehicle(vehicle);
	};

	// Update the selected vehicle in the delivery context
	// This function is called when a vehicle is selected
	const updateDeliveryVehicle = useCallback(
		(vehicleType: string, maxWeight: number) => {
			setNewDelivery((prevDelivery) => {
				// If no delivery exists, create a new one with default values
				if (!prevDelivery) {
					return {
						txnIDs: [], // Initialize with an empty list of transaction IDs
						vehicleType,
						maxWeight,
						currentWeight: 0, // Default weight
					};
				}

				// If a delivery exists, update the vehicle type and max weight if it can carry the current weight
				if (prevDelivery.currentWeight > maxWeight) {
					return prevDelivery;
				} else {
					return { ...prevDelivery, vehicleType, maxWeight };
				}
			});
		},
		[setNewDelivery]
	);

	return (
		<div className="d-flex justify-content-center">
			<div className="container">
				<div className="row">
					{vehicles.map((vehicle) => (
						<div className="col-6 mb-4" key={vehicle.$id}>
							<div
								className={`card ${
									selectedVehicle?.$id === vehicle.$id
										? "border-primary shadow"
										: ""
								}`}
								onClick={() => handleSelectVehicle(vehicle)}
								style={{
									cursor: "pointer",
								}}>
								<div className="card-body">
									<h5 className="card-title">{vehicle.vehicleType}</h5>
									<p className="card-text">
										Max: <strong>{vehicle.maxWeight}</strong> kgs
									</p>
									<p className="card-text">Notes: {vehicle.notes}</p>
								</div>
							</div>
						</div>
					))}
				</div>
			</div>
		</div>
	);
}

export default TruckDisplay;
