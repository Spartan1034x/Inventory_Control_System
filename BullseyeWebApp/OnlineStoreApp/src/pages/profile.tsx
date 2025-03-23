import { useState, useEffect } from "react";
import { getOrders } from "../DatabaseOps";

type Order = {
	barCode: string;
	deliveryId: number;
	emergencyDelivery: boolean;
	notes: string;
	shipDate: string;
	siteTo: string;
	totalItems: number;
	totalWeight: number;
	txnId: number;
	txnStatus: string;
	txnType: string;
};

function Profile() {
	const [orderID, setOrderID] = useState<number>(0);
	const [email, setEmail] = useState<string>("");
	const [orderPageVisible, setOrderPageVisible] = useState<boolean>(false);

	const [orders, setOrders] = useState<Order[]>([]); // Add a state to all store orders
	const [searchedOrder, setSearchedOrder] = useState<Order[]>([]); // Add a state to store the searched order

	useEffect(() => {
		const fetchOrders = async () => {
			try {
				const data = await getOrders();

				// Filter orders to only show online orders
				const filteredOrders =
					data?.$values.filter(
						(order: Order) =>
							order.txnType.toLowerCase() === "Online".toLowerCase()
					) || [];

				setOrders(filteredOrders);
			} catch (error) {
				console.error("Failed to fetch orders:", error);
			}
		};
		fetchOrders();
	}, []); // Empty dependency array ensures the effect runs only once, if it has dependencies, it runs whenever they change

	// Function to search for order by order ID or email or both
	const searchOrder = () => {
		// If email is populated validate
		if (email !== "") {
			if (!validateEmail(email)) return;
		}

		console.log("Order ID: " + orderID);
		console.log("Email: " + email);
		// If txnID is greater than 0, if email is populated search by both
		if (orderID > 0 && email !== "") {
			// Add order to searched order if order ID and email matches
			orders.forEach((order) => {
				if (order.txnId === orderID && order.notes.includes(email)) {
					setSearchedOrder([order]);
				} else {
					alert("No orders found with that order ID and email");
					setSearchedOrder([]);
				}
			});
		} else if (orderID > 0) {
			// Add order to searched order if order ID matches
			orders.forEach((order) => {
				if (order.txnId === orderID) {
					setSearchedOrder([order]);
				} else {
					alert("No orders found with that order ID");
					setSearchedOrder([]);
				}
			});
		} else if (email !== "") {
			// Add order to searched order if email matches
			orders.forEach((order) => {
				if (order.notes.includes(email)) {
					setSearchedOrder([order]);
				} else {
					alert("No orders found with that email");
					setSearchedOrder([]);
				}
			});
		} else {
			alert("Please enter an order ID or email to search for an order");
			setSearchedOrder([]);
			return;
		}

		// If order is found set order page visible
		setOrderPageVisible(true);
	};

	// Function to validate email if email state is not empty
	const validateEmail = (email: string) => {
		if (email.includes("@") && email.includes(".com") && email.length > 5) {
			return true;
		}
		alert("Please enter a valid email address or leave empty");
		return false;
	};

	return (
		<div
			style={{
				background: "linear-gradient(90deg, #00C9FF 0%, #92FE9D 100%)",
				height: "90vh",
				overflowY: "auto",
			}}>
			<div className="container">
				<div className="row">
					<div className="col-12">
						<h1 className="text-center py-3">Your Orders</h1>
					</div>
				</div>
				<div className="row">
					<div className="col-12">
						<div className="card">
							<div className="card-body">
								<h5 className="card-title text-center pb-3">
									User Information
								</h5>
								<div className="card-text d-flex align-items-center col-6">
									<label htmlFor="id" className="form-label col-5">
										Transaction ID:
									</label>
									<input
										type="number"
										id="id"
										value={orderID}
										onChange={(e) => setOrderID(parseInt(e.target.value))}
										min={0}
										className="form-control"
									/>
								</div>
								<div className="card-text d-flex align-items-center col-6 py-5">
									<label htmlFor="email" className="form-label col-5">
										Email:
									</label>
									<input
										type="email"
										id="email"
										value={email}
										placeholder="yourEmail@hotmail.com"
										onChange={(e) => setEmail(e.target.value)}
										className="form-control"
									/>
								</div>
								<div className="card-text d-flex align-items-center justify-content-center">
									<p
										className="btn btn-primary"
										onClick={() => {
											searchOrder();
										}}>
										View Order Info
									</p>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
			<div className={orderPageVisible ? "visible" : "invisible"}>
				<div className="container bg-success-subtle my-3 p-4 rounded">
					{searchedOrder.map((order, index) => (
						<div key={index} className="card mb-3">
							<div className="card-body">
								<h3 className="card-title text-center mb-4">
									Status:{" "}
									<span className="badge bg-success">{order.txnStatus}</span>
								</h3>

								<div className="row mb-3">
									<div className="col-12">
										<h5 className="text-center">
											Transaction ID: {order.txnId}
										</h5>
									</div>
								</div>

								<div className="row">
									<div className="col-md-6">
										<div className="form-group">
											<label htmlFor="shipDate">Pick Up Time</label>
											<input
												type="text"
												id="shipDate"
												className="form-control"
												value={order.shipDate}
												readOnly
											/>
										</div>
									</div>
									<div className="col-md-6">
										<div className="form-group">
											<label htmlFor="siteTo">Pickup Location</label>
											<input
												type="text"
												id="siteTo"
												className="form-control"
												value={order.siteTo}
												readOnly
											/>
										</div>
									</div>
								</div>
								<div className="row mt-3">
									<div className="col-md-6">
										<div className="form-group">
											<label htmlFor="totalItems">Total Items</label>
											<input
												type="text"
												id="totalItems"
												className="form-control"
												value={order.totalItems}
												readOnly
											/>
										</div>
									</div>
									<div className="col-md-6">
										<div className="form-group">
											<label htmlFor="totalWeight">Total Weight</label>
											<input
												type="text"
												id="totalWeight"
												className="form-control"
												value={order.totalWeight + " kgs"}
												readOnly
											/>
										</div>
									</div>
								</div>
							</div>
						</div>
					))}
				</div>
			</div>
		</div>
	);
}

export default Profile;
