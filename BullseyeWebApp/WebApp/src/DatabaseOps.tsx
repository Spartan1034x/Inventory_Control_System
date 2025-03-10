import axios from "axios";

const getOrders = async () => {
	try {
		const response = await axios.get("https://localhost:7265/api/Txn");
		console.log(response.data);
		return response.data;
	} catch (error) {
		console.error(error);
	}
};

export { getOrders };
