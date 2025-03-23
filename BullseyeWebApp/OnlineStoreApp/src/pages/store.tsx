import { useSite } from "../contexts/SiteContext";
import SelectStore from "./storeComponents/selectStore";
import StoreCards from "./storeComponents/StoreCards";
import CategoryDropdown from "./storeComponents/CategoryDropdown";

function Store() {
	const { selectedSite } = useSite();

	return (
		<div
			style={{
				background: "linear-gradient(90deg, #00C9FF 0%, #92FE9D 100%)",
				height: "90vh",
				overflowY: "hidden",
			}}>
			{selectedSite && <CategoryDropdown />}
			{(selectedSite == null || selectedSite == undefined) && <SelectStore />}
			{selectedSite && <StoreCards />}
		</div>
	);
}

export default Store;
