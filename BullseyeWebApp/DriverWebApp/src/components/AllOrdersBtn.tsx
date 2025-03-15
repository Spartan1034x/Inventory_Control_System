//import { useState, useEffect } from "react";

import { useOrders } from "../contexts/OrdersContext";

function ShowAllButton() {
	const { orders, filteredOrders, setFilteredOrders } = useOrders();

	const handleShowAllClick = () => {
		if (filteredOrders.length === orders.length) {
			// Show only "ASSEMBLED" if clicked and all orders are shown
			setFilteredOrders(
				orders.filter((order) => order.txnStatus === "ASSEMBLED")
			);
		} else {
			// Show all orders
			setFilteredOrders(orders);
		}
	};

	const buttonText =
		filteredOrders.length === orders.length
			? "Show Assembled Orders"
			: "Show All Orders";

	return (
		<div className="d-flex justify-content-center col">
			<button
				className="btn btn-secondary"
				onClick={() => handleShowAllClick()}>
				{buttonText}
			</button>
		</div>
	);
}

export default ShowAllButton;
