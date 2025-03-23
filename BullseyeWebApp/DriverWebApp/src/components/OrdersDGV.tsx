import { useState, useEffect } from "react";
import {
	getCoreRowModel,
	getSortedRowModel,
	useReactTable,
	flexRender,
} from "@tanstack/react-table";
import { useOrders } from "../contexts/OrdersContext";
import { useDeliveries } from "../contexts/DeliveryContext";

function OrdersDataTable() {
	// From context, orders data, and selected order state
	const {
		orders,
		filteredOrders,
		selectedOrder,
		setSelectedOrder,
		setFilteredOrders,
	} = useOrders();

	// From context newDelivery
	const { newDelivery } = useDeliveries();

	// Add a sorting state
	const [sorting, setSorting] = useState([]);

	// Define table columns
	const columns = [
		{ header: "ID", accessorKey: "txnId" },
		{ header: "Barcode", accessorKey: "barCode" },
		{ header: "Site To", accessorKey: "siteTo" },
		{ header: "Total Items", accessorKey: "totalItems" },
		{ header: "Total Weight (kgs)", accessorKey: "totalWeight" },
		{ header: "Ship Date", accessorKey: "shipDate" },
		{ header: "Status", accessorKey: "txnStatus" },
		{
			header: "Emergency",
			accessorKey: "emergencyDelivery",
			cell: ({ getValue }) => (getValue() ? "YES" : "NO"),
		},
	];

	// Initially sort orders to just show orders that are submitted
	useEffect(() => {
		setFilteredOrders(
			orders.filter((order) => order.txnStatus === "ASSEMBLED")
		);
	}, [orders, setFilteredOrders]); // Runs once on load and when orders change

	// Initialize React Table
	const table = useReactTable({
		data: filteredOrders,
		columns,
		getCoreRowModel: getCoreRowModel(),
		getSortedRowModel: getSortedRowModel(), // Enable sorting
		state: {
			sorting, // Pass sorting state
		},
		onSortingChange: setSorting, // Update sorting state on changes
	});

	// Handle row selection
	const handleRowClick = (row) => {
		const orderId = Number(row.original.txnId);
		const weight = Number(row.original.totalWeight);
		const date = row.original.shipDate;
		setSelectedOrder({ txnId: orderId, totalWeight: weight, shipDate: date });
	};

	return (
		<div className="table-responsive border border-dark border-2">
			<table className="table table-striped table-bordered table-hover">
				<thead className="table-dark">
					{table.getHeaderGroups().map((headerGroup) => (
						<tr key={headerGroup.id}>
							{headerGroup.headers.map((header) => (
								// Make headers clickable to sort
								<th
									key={header.id}
									onClick={header.column.getToggleSortingHandler()}
									style={{ cursor: "pointer" }} // So user knows it's clickable
								>
									{flexRender(
										header.column.columnDef.header,
										header.getContext()
									)}
									{/* Show sorting indicator */}
									{header.column.getIsSorted() === "asc"
										? " 🔼"
										: header.column.getIsSorted() === "desc"
										? " 🔽"
										: ""}
								</th>
							))}
						</tr>
					))}
				</thead>
				<tbody>
					{table.getRowModel().rows.map((row) => {
						const isInDelivery = newDelivery?.txnIDs?.includes(
							row.original.txnId
						);

						return (
							<tr
								key={row.original.txnId}
								className={`${
									String(selectedOrder?.txnId) === String(row.original.txnId)
										? "table-primary" // Highlight selected row
										: isInDelivery
										? "table-success" // Highlight rows in delivery
										: ""
								}`}
								onClick={() => handleRowClick(row)}>
								{row.getVisibleCells().map((cell) => (
									<td key={cell.id}>
										{flexRender(cell.column.columnDef.cell, cell.getContext())}
									</td>
								))}
							</tr>
						);
					})}
				</tbody>
			</table>
		</div>
	);
}

export default OrdersDataTable;
