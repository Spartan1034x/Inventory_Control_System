import { getInventoryById } from "../DatabaseOps";
import { useSite } from "./SiteContext";

import {
	useEffect,
	useState,
	ReactNode,
	createContext,
	useContext,
} from "react";

// Inventory type
export type Inventory = {
	itemID: number;
	siteID: number;
	name: string;
	description: string;
	quantity: number;
	price: number;
	category: string;
	sku: string;
	imageLocation: string;
};

interface InventoryContextType {
	inventory: Inventory[];
	cart: Inventory[];
	filteredInventory: Inventory[];
	searchedInventory: Inventory[];
	setFilteredInventory: (inventory: Inventory[]) => void;
	setSearchedInventory: (inventory: Inventory[]) => void;
	setCart: React.Dispatch<React.SetStateAction<Inventory[]>>;
	setInventory: React.Dispatch<React.SetStateAction<Inventory[]>>;
}

const InventoryContext = createContext<InventoryContextType>({
	inventory: [],
	cart: [],
	filteredInventory: [],
	searchedInventory: [],
	setFilteredInventory: () => {},
	setSearchedInventory: () => {},
	setCart: () => {},
	setInventory: () => {},
});

export function InventoryProvider({ children }: { children: ReactNode }) {
	const [inventory, setInventory] = useState<Inventory[]>([]); // State to store the inventory
	const [filteredInventory, setFilteredInventory] = useState<Inventory[]>([]); // State to store the filtered inventory
	const [searchedInventory, setSearchedInventory] = useState<Inventory[]>([]); // State to store the searched inventory before a search
	const [cart, setCart] = useState<Inventory[]>([]); // State to store the cart

	const { selectedSite } = useSite();

	// Clear the cart when a new site is selected
	useEffect(() => {
		setCart([]);
	}, [selectedSite?.id, setCart]); // Will run only when selected site changes as setCart is function and does not change

	// Fetch inventory by site ID, updates when selectedSite changes
	useEffect(() => {
		const fetchInventory = async () => {
			try {
				if (selectedSite?.id !== undefined) {
					const data = await getInventoryById(selectedSite.id);
					setInventory(data?.$values);
				}
			} catch (error) {
				console.error(error);
			}
		};
		fetchInventory();
	}, [selectedSite]);

	return (
		<InventoryContext.Provider
			value={{
				inventory,
				setInventory,
				cart,
				filteredInventory,
				searchedInventory,
				setFilteredInventory,
				setSearchedInventory,
				setCart,
			}}>
			{children}
		</InventoryContext.Provider>
	);
}

// eslint-disable-next-line react-refresh/only-export-components
export function useInventory() {
	const context = useContext(InventoryContext);
	return context;
}
