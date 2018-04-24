import { Component, OnInit } from "@angular/core";
import { Location } from '@angular/common';
import { ActivatedRoute } from "@angular/router";
import {
  ProjectsClient,
  ProjectStatus,
  Project,
  UpdateProjectModel
} from "../../clients/project.client";

@Component({
  selector: "project",
  templateUrl: "./project.component.html"
})
export class ProjectComponent implements OnInit {
  client: ProjectsClient;
  route: ActivatedRoute;
  location: Location;
  project: Project;
  statuses: ProjectStatus[] = [ProjectStatus.Active, ProjectStatus.Inactive];

  constructor(client: ProjectsClient, route: ActivatedRoute, location: Location) {
    this.client = client;
    this.route = route;
    this.location = location;
  }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get("id");
    this.client
      .getById(id)
      .subscribe(x => {
        this.project = x;
      });
  }

  goBack(): void {
    this.location.back();
  }

  update(): void {
    this.client
      .update(this.project.id, new UpdateProjectModel({ name: this.project.name, description: this.project.description, status: this.project.status }))
      .subscribe(x => {
        console.log("updated")
      });
  }
}
