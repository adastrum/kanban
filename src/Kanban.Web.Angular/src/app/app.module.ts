import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";
import { FormsModule } from "@angular/forms";

import { AppComponent } from "./app.component";
import { ProjectsComponent } from "./components/project/projects.component";
import { ProjectsClient, API_BASE_URL } from "./clients/project.client";
import { AppRoutingModule } from "./app-routing.module";
import { ProjectComponent } from "./components/project/project.component";

@NgModule({
  declarations: [AppComponent, ProjectsComponent, ProjectComponent],
  imports: [BrowserModule, HttpClientModule, AppRoutingModule, FormsModule],
  providers: [
    ProjectsClient,
    {
      provide: API_BASE_URL,
      useValue: "http://kanban.api"
      // useValue: "http://localhost:55146"
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
