import { Component, OnInit } from "@angular/core";
import {
  ProjectsClient,
  ProjectStatus,
  ProjectModel
} from "../../clients/project.client";

@Component({
  selector: "projects",
  templateUrl: "./projects.component.html"
})
export class ProjectsComponent implements OnInit {
  client: ProjectsClient;
  projects: ProjectModel[];

  constructor(client: ProjectsClient) {
    this.client = client;
  }

  ngOnInit(): void {
    this.client.getByFilter("", "", null).subscribe(x => {
      this.projects = x;
    });
  }
}
