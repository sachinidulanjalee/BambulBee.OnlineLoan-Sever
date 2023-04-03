import React, { Component } from "react";
import ListMainClassification from "./ListMainClassification";
import AddMainClassification from "./AddMainClassification";
import Tablist from "../Common/Tablist";

export default class Index extends Component {
	constructor(props) {
		super(props);
		this.state = { mainClassification: [] };

	}


	render() {
		return (
			<div>
				<div className="content-wrapper">
					<section className="content-header">
						<div className="container-fluid">
							<div className="row mb-2">
								<div className="col-sm-6"></div>
								<div className="col-sm-6">
									<ol className="breadcrumb float-sm-right">
										<li className="breadcrumb-item"><a href="/Home">Home</a></li>
										<li className="breadcrumb-item active">Main Classification</li>
									</ol>
								</div>
							</div>
						</div>
					</section>

					<section className="content">
						<div className="container-fluid">
							<div className="col-md-12">
								<div className="card card-outline card-primary">
									<div className="card-header">
										<h1 className="card-title"><b>Main Classification</b></h1>
									</div>
									<div className="card-body">
										<div className="row mt-1">
											{/* {this.state.tab.map(this.CreateTablist)} */}
											
											<nav className="w-100">
												<div className="nav nav-tabs nav-pills" id="nav-tab" role="tablist">
													<a className="nav-item nav-link active" id="list-tab" data-toggle="tab" href="#list-desc" role="tab" aria-controls="list-desc" aria-selected="true">All</a>
													<a className="nav-item nav-link" id="add-tab" data-toggle="tab" href="#add-desc" role="tab" aria-controls="add-desc" aria-selected="false">Add</a>
												</div>
											</nav>

											<div className="tab-content w-100" id="nav-tabContent">
												<div className="tab-pane fade show active table-responsive" id="list-desc" role="tabpanel" aria-labelledby="list-tab">
													<ListMainClassification />
												</div>
												<div className="tab-pane fade" id="add-desc" role="tabpanel" aria-labelledby="add-tab">
													<AddMainClassification />
												</div>
											</div>
										</div>
									</div>
								</div>
							</div>
						</div>
					</section>
				</div>
			</div>

		);
	}
}