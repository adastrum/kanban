import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";
import { FormsModule } from "@angular/forms";

import { AppComponent } from "./app.component";
import { ProjectsComponent } from "./components/project/projects.component";
import { ProjectsClient } from "./clients/project.client";
import { ProjectTasksClient } from "./clients/project.task.client";
import { AppRoutingModule } from "./app-routing.module";
import { ProjectComponent } from "./components/project/project.component";
// import { ProjectClientMock } from "./clients/project.client.mock";
import { API_BASE_URL } from "./globals";

@NgModule({
  declarations: [AppComponent, ProjectsComponent, ProjectComponent],
  imports: [BrowserModule, HttpClientModule, AppRoutingModule, FormsModule],
  providers: [
    // { provide: ProjectsClient, useClass: ProjectClientMock },
    ProjectsClient,
    ProjectTasksClient,
    {
      provide: API_BASE_URL,
      // useValue: "http://kanban.api"
      useValue: "http://localhost:55146"
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
