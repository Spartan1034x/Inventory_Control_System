import { getVehicle } from "../DatabaseOps";
import {
	useEffect,
	useState,
	ReactNode,
	createContext,
	useContext,
} from "react";

interface VehicleContextType {
	vehicles: any[];
	selectedVehicle: any | null;
	setSelectedVehicle: (vehicle: any | null) => void;
}

const VehicleContext = createContext<VehicleContextType | undefined>(undefined);

export function VehicleProvider({ children }: { children: ReactNode }) {
	const [vehicles, setVehicles] = useState<any[]>([]); // Array of vehicles
	const [selectedVehicle, setSelectedVehicle] = useState<any | null>(null); // Selected vehicle

	useEffect(() => {
		const fetchVehicles = async () => {
			try {
				const data = await getVehicle();
				setVehicles(data?.$values || []);
			} catch (error) {
				console.error("Failed to fetch vehicles:", error);
			}
		};
		fetchVehicles();
	}, []);

	return (
		<VehicleContext.Provider
			value={{ vehicles, selectedVehicle, setSelectedVehicle }}>
			{children}
		</VehicleContext.Provider>
	);
}

// Custom hook to use OrdersContext
export function useVehicles() {
	const context = useContext(VehicleContext);
	if (!context) {
		throw new Error("useOrders must be used within an OrdersProvider");
	}
	return context;
}
