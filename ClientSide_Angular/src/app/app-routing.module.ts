import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContactDashboardComponent } from './components/contact-dashboard/contact-dashboard.component';
import { AddContactComponent } from './components/add-contact/add-contact.component';

const routes: Routes = [
  { path: '', component: ContactDashboardComponent, pathMatch: 'full' },
  { path: 'add-contact', component: AddContactComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
