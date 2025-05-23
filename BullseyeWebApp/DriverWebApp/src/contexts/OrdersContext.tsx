import {
	createContext,
	useContext,
	useEffect,
	useState,
	ReactNode,
} from "react";
import { getOrders } from "../DatabaseOps";

// Selected Order type
type SelectedOrderType = {
	txnId: string;
	totalWeight: number;
	shipDate: string;
};

// Define the shape of the context
interface OrdersContextType {
	orders: any[];
	selectedOrder: SelectedOrderType | null;
	setSelectedOrder: (order: any | null) => void;
	setFilteredOrders: (orders: any[]) => void;
	filteredOrders: any[];
}

// Create the context with default values
const OrdersContext = createContext<OrdersContextType | undefined>(undefined);

export function OrdersProvider({ children }: { children: ReactNode }) {
	// State to store orders and selected order
	// useState stores the initial state of the context and provides a function to update it

	const [orders, setOrders] = useState<any[]>([]); // Add a state to all store orders
	const [selectedOrder, setSelectedOrder] = useState<SelectedOrderType | null>(
		null
	); // Add a state to store selected order
	const [filteredOrders, setFilteredOrders] = useState<any[]>([]); // Add a state to store filtered orders

	/*useEffect(() => {
		console.log("Selected Order ID:", selectedOrder);
	}, [selectedOrder]);*/

	/* useEffect(() => {
		console.log("Orders:", orders);
	}, [orders]); */

	/* useEffect(() => {
		console.log("Filtered Orders:", filteredOrders);
	}, [filteredOrders]); */

	// useEffect is used to fetch orders from the database
	// It runs once when the component is mounted
	useEffect(() => {
		const fetchOrders = async () => {
			try {
				const data = await getOrders();

				// Filter orders to not show online orders
				const filteredOrders =
					data?.$values.filter(
						(order) => order.txnType.toLowerCase() !== "Online".toLowerCase()
					) || [];

				setOrders(filteredOrders);
			} catch (error) {
				console.error("Failed to fetch orders:", error);
			}
		};
		fetchOrders();
	}, []); // Empty dependency array ensures the effect runs only once, if it has dependencies, it runs whenever they change

	return (
		<OrdersContext.Provider
			value={{
				orders,
				filteredOrders,
				selectedOrder,
				setSelectedOrder,
				setFilteredOrders,
			}}>
			{children}
		</OrdersContext.Provider>
	);
}

// Custom hook to use OrdersContext
export function useOrders() {
	const context = useContext(OrdersContext);
	if (!context) {
		throw new Error("useOrders must be used within an OrdersProvider");
	}
	return context;
}
