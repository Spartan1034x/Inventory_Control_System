import { getDeliveries } from "../DatabaseOps";

import {
	useEffect,
	useState,
	ReactNode,
	createContext,
	useContext,
} from "react";

interface DeliveryContextType {
	deliveries: any[];
	newDelivery: CurrentDelivery | null;
	setNewDelivery: React.Dispatch<React.SetStateAction<CurrentDelivery | null>>;
}

const DeliveryContext = createContext<DeliveryContextType | undefined>(
	undefined
);

// All a new delivery needs from the front end is a list of txn IDs and a vehicle type
type DeliveryDTO = {
	deliveryID: number;
	txnIDs: number[];
	vehicleType: string;
	emergencyOrder: boolean;
	totalWeight: number;
	deliveryDate: string;
	notes: string;
};

// Type for current delivery on front end, first line error checking for weight and such
type CurrentDelivery = {
	txnIDs: number[];
	vehicleType: string;
	maxWeight: number;
	currentWeight: number;
};

export function DeliveryProvider({ children }: { children: ReactNode }) {
	const [deliveries, setDeliveries] = useState<any[]>([]); // Array of deliveries
	const [newDelivery, setNewDelivery] = useState<CurrentDelivery | null>(null); // New delivery

	/* useEffect(() => {
		console.log(newDelivery);
	}, [newDelivery]); */

	useEffect(() => {
		const fetchDeliveries = async () => {
			try {
				const data = await getDeliveries();
				setDeliveries(data?.$values || []);
			} catch (error) {
				console.error("Failed to fetch deliveries:", error);
			}
		};
		fetchDeliveries();
	}, []);

	return (
		<DeliveryContext.Provider
			value={{ deliveries, newDelivery, setNewDelivery }}>
			{children}
		</DeliveryContext.Provider>
	);
}

export function useDeliveries() {
	const context = useContext(DeliveryContext);
	if (!context) {
		throw new Error("useDeliveries must be used within a DeliveryProvider");
	}
	return context;
}

export type { DeliveryDTO, CurrentDelivery };
