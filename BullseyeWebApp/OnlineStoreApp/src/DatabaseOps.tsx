import axios from "axios";

// Get all Sites
export const getAllSites = async () => {
	try {
		const response = await axios.get("https://localhost:7265/api/Site");
		//console.log(response.data);
		return response.data;
	} catch (error) {
		console.error(error);
	}
};

// Get inventory by store ID
export const getInventoryById = async (siteId: number) => {
	try {
		const response = await axios.get(
			`https://localhost:7265/api/Inventory/${siteId}`
		);
		return response.data;
	} catch (error) {
		console.error(error);
	}
};

export type TxnDTO = {
	siteIdTo: number;
	notes?: string;
	items: {
		itemId: number;
		quantity: number;
	}[];
};

// Post a transaction
export const postTxn = async (txn: TxnDTO) => {
	try {
		const response = await axios.post("https://localhost:7265/api/Txn", txn);
		return response.data;
	} catch (error) {
		console.error(error);
	}
};

// Get all orders
export const getOrders = async () => {
	try {
		const response = await axios.get("https://localhost:7265/api/Txn");
		//console.log(response.data);
		return response.data;
	} catch (error) {
		console.error(error);
	}
};

// Get order by order ID
export const getOrderById = async (orderId: number) => {
	try {
		const response = await axios.get(
			`https://localhost:7265/api/Txn/${orderId}`
		);
		return response.data;
	} catch (error) {
		console.error(error);
	}
};
