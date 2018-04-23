import { Component, OnInit } from "@angular/core";
import {
  ProjectsClient,
  ProjectStatus,
  Project,
  ProjectFilter
} from "../../clients/project.client";

@Component({
  selector: "projects",
  templateUrl: "./projects.component.html"
})
export class ProjectsComponent implements OnInit {
  filter: ProjectFilter;
  projects: Project[];
  client: ProjectsClient;

  constructor(client: ProjectsClient) {
    this.client = client;
  }

  ngOnInit(): void {
    this.filter = new ProjectFilter();
    this.client.getProjects(this.filter).subscribe(x => {
      this.projects = x;
    });
  }
}
