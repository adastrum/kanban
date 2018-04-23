import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { ProjectsComponent } from "./components/project/projects.component";
import { ProjectComponent } from "./components/project/project.component";

const routes: Routes = [
  { path: "", redirectTo: "/projects", pathMatch: "full" },
  {
    path: "projects",
    component: ProjectsComponent,
    pathMatch: "full"
  },
  {
    path: "projects/:id",
    component: ProjectComponent
  },
  { path: "**", redirectTo: "/projects", pathMatch: "full" }
];

@NgModule({
  exports: [RouterModule],
  imports: [RouterModule.forRoot(routes)]
})
export class AppRoutingModule {}
