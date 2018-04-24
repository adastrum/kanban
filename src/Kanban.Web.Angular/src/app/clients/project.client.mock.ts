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

    getByFilter(filter: ProjectFilter): Observable<Project[]> {
        return Observable.of(this.projects);
    }
    create(model: CreateProjectModel): Observable<object> {
        let count = this.projects.length;
        let id = `id${count + 1}`;
        let project = new Project();
        project.id = id;
        project.name = model.name;
        project.description = model.description;
        project.status = model.status;
        this.projects.push(project);

        return Observable.of(null);
    }
    getById(id: string): Observable<Project> {
        return Observable.of(this.projects.find(x => x.id == id));
    }
    update(id: string, model: UpdateProjectModel): Observable<object> {
        let index = this.projects.findIndex(x => x.id == id);
        let project = new Project();
        project.id = id;
        project.name = model.name;
        project.description = model.description;
        project.status = model.status;
        this.projects[index] = project;

        return Observable.of(null);
    }
    delete(id: string): Observable<object> {
        let index = this.projects.findIndex(x => x.id == id);
        delete this.projects[id];

        return Observable.of(null);
    }
}
