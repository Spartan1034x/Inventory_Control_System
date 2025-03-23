import { useEffect, useState } from "react";
import { useOrders } from "../contexts/OrdersContext";

function DatePicker() {
	const [date, setDate] = useState(() => new Date());
	const { orders, setFilteredOrders } = useOrders();

	// Runs when date changes, when orders changes(once on load), and when setFilteredOrders changes (once on load)
	useEffect(() => {
		//console.log(date, typeof date);
		// Update the filtered orders based on the selected date
		const filtered = orders.filter((order) => {
			const orderDate = order.shipDate.slice(0, 10);
			const selectedDateSliced = date.toISOString().slice(0, 10);
			return orderDate === selectedDateSliced;
		});
		setFilteredOrders(filtered);
	}, [date, orders, setFilteredOrders]);

	return (
		<div className="col-3">
			<h4 className="mt-3">Filter Orders by Date</h4>
			<div className="input-group mt-3">
				<input
					type="date"
					className="form-control"
					value={date.toISOString().split("T")[0]}
					onChange={(e) => setDate(new Date(e.target.value))}
				/>
			</div>
		</div>
	);
}

export default DatePicker;
