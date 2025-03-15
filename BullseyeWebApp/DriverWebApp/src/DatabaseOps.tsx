import axios from "axios";
import { DeliveryDTO } from "./contexts/DeliveryContext";

// Get all orders
const getOrders = async () => {
	try {
		const response = await axios.get("https://localhost:7265/api/Txn");
		//console.log(response.data);
		return response.data;
	} catch (error) {
		console.error(error);
	}
};

// Get all vehicles
const getVehicle = async () => {
	try {
		const response = await axios.get("https://localhost:7265/api/Vehicle");
		//console.log(response.data);
		return response.data;
	} catch (error) {
		console.error(error);
	}
};

// Get all deliveries
const getDeliveries = async () => {
	try {
		const response = await axios.get("https://localhost:7265/api/Delivery");
		//console.log(response.data);
		return response.data;
	} catch (error) {
		console.error(error);
	}
};

// Post a new delivery (create a new delivery)
const createDelivery = async (delivery: DeliveryDTO) => {
	try {
		const response = await axios.post(
			"https://localhost:7265/api/Delivery",
			delivery
		);
		return response.data;
	} catch (error) {
		console.error(error);
	}
};

export { getOrders, getVehicle, getDeliveries, createDelivery };
