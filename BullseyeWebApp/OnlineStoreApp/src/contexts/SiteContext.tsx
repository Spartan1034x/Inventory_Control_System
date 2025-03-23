import { getAllSites } from "../DatabaseOps";

import {
	useEffect,
	useState,
	ReactNode,
	createContext,
	useContext,
} from "react";

// Site type
type Site = {
	id: number;
	name: string;
	address: string;
	city: string;
	phone: string;
};

// Context type
interface SiteContextType {
	sites: Site[];
	selectedSite: Site | null;
	setSelectedSite: (site: Site) => void;
}

// Context
const SiteContext = createContext<SiteContextType>({
	sites: [],
	selectedSite: null,
	setSelectedSite: () => {},
});

// Provider
// This is a custom hook that will be used to provide the context to the components that need it
export function SiteProvider({ children }: { children: ReactNode }) {
	const [sites, setSites] = useState<Site[]>([]); // State to store the sites
	const [selectedSite, setSelectedSite] = useState<Site | null>(null); // State to store the selected site

	// Fetch all sites
	useEffect(() => {
		const fetchSites = async () => {
			try {
				const data = await getAllSites();
				setSites(data?.$values);
			} catch (error) {
				console.error(error);
			}
		};
		fetchSites();
	}, []);

	return (
		<SiteContext.Provider value={{ sites, selectedSite, setSelectedSite }}>
			{children}
		</SiteContext.Provider>
	);
}

// Hook to use Context
export function useSite() {
	const context = useContext(SiteContext);
	if (!context) {
		throw new Error("useSite must be used within a SiteProvider");
	}
	return context;
}
