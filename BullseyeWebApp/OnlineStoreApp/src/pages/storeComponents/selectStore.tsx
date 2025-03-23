import { useSite } from "../../contexts/SiteContext";

function SelectStore() {
	const { sites, setSelectedSite } = useSite();
	return (
		<div>
			<div className="d-flex justify-content-center mb-5 pt-5">
				<h1>Please Select a Store</h1>
			</div>
			<div
				style={{
					width: "50%",
					display: "block",
					margin: "auto",
					border: "1px solid black",
					borderRadius: "10px",
					padding: "10px",
				}}>
				<div className="accordion accordion-flush" id="accordionFlushExample">
					{sites.map((site) => (
						<div className="accordion-item" key={site.id}>
							<h2 className="accordion-header" id={`flush-heading-${site.id}`}>
								<button
									className="accordion-button collapsed"
									type="button"
									data-bs-toggle="collapse"
									data-bs-target={`#flush-collapse-${site.id}`}
									aria-expanded="false"
									aria-controls={`flush-collapse-${site.id}`}>
									{site.name}
								</button>
							</h2>
							<div
								id={`flush-collapse-${site.id}`}
								className="accordion-collapse collapse"
								aria-labelledby={`flush-heading-${site.id}`}
								data-bs-parent="#accordionFlushExample">
								<div className="accordion-body">
									<p>{site.address + ", " + site.city}</p>
									<p className="d-flex justify-content-between">
										<span>{FormatPhoneNumber(site.phone)} </span>
										<span>
											<button
												type="button"
												className="btn btn-primary"
												onClick={() => setSelectedSite(site)}>
												Set Active
											</button>
										</span>
									</p>
								</div>
							</div>
						</div>
					))}
				</div>
			</div>
		</div>
	);
}

export default SelectStore;

function FormatPhoneNumber(phoneNumberString) {
	const cleaned = ("" + phoneNumberString).replace(/\D/g, "");
	const match = cleaned.match(/^(\d{3})(\d{3})(\d{4})$/);
	if (match) {
		return "(" + match[1] + ") " + match[2] + "-" + match[3];
	}
	return null;
}
