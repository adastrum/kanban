import { Component, OnInit } from "@angular/core";
import { Location } from '@angular/common';
import { ActivatedRoute } from "@angular/router";
import {
  ProjectsClient,
  ProjectStatus,
  Project
} from "../../clients/project.client";

@Component({
  selector: "project",
  templateUrl: "./project.component.html"
})
export class ProjectComponent implements OnInit {
  project: Project;
  client: ProjectsClient;
  route: ActivatedRoute;
  location: Location;

  constructor(client: ProjectsClient, route: ActivatedRoute, location: Location) {
    this.client = client;
    this.route = route;
    this.location = location;
  }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get("id");
    this.client.getProjectById(id).subscribe(x => {
      this.project = x;
    });
  }

  goBack(): void {
    this.location.back();
  }
}
