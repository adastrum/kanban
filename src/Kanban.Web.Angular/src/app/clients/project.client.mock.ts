import { IProjectsClient, ProjectFilter, CreateProjectModel, Project, UpdateProjectModel, ProjectStatus } from "./project.client";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";

@Injectable()
export class ProjectClientMock implements IProjectsClient {
    projects: Project[] = [
        { id: "id1", name: "name1", description: "description1", status: ProjectStatus.Active },
        { id: "id2", name: "name2", description: "description2", status: ProjectStatus.Inactive }
    ];

    constructor() { }

    getProjects(filter: ProjectFilter): Observable<Project[]> {
        return Observable.of(this.projects);
    }
    createProject(model: CreateProjectModel): Observable<object> {
        throw new Error("Method not implemented.");
    }
    getProjectById(id: string): Observable<Project> {
        throw new Error("Method not implemented.");
    }
    put(id: string, model: UpdateProjectModel): Observable<object> {
        throw new Error("Method not implemented.");
    }
    delete(id: string): Observable<object> {
        throw new Error("Method not implemented.");
    }
}
