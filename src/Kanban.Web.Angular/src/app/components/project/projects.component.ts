import { Component, OnInit } from "@angular/core";
import { ProjectsClient, ProjectStatus } from "../../clients/project.client";

@Component({
  selector: "projects",
  templateUrl: "./projects.component.html"
})
export class ProjectsComponent implements OnInit {
  projects: any[];
  client: ProjectsClient;

  constructor(client: ProjectsClient) {
    this.client = client;
  }

  ngOnInit(): void {
    this.client.getProjects("", "", null).subscribe(x => {
      console.log(x);
    });
  }
}
