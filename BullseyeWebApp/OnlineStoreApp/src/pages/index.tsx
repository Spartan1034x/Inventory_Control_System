function IndexPage() {
	return (
		<div
			style={{
				background: "linear-gradient(90deg, #00C9FF 0%, #92FE9D 100%)",
				height: "90vh",
			}}
			className="d-flex flex-column justify-content-center">
			<div className="text-center">
				<img
					src="/images/Logo-removebg-preview.png"
					alt="Logo"
					width="285"
					height="247"
				/>
			</div>
			<h1 className="text-center m-3">Welcome to Bullseye Online</h1>
			<div className="text-center fs-5">
				Your favourite Canadian owned and operated store since 1969
			</div>
		</div>
	);
}

export default IndexPage;
