import { Component } from '@angular/core';
import { ContactService } from '../../services/contact/contact.service';
import { Contact } from '../../models/contact.model';
import { Router } from '@angular/router';
@Component({
  selector: 'app-contact-dashboard',
  templateUrl: './contact-dashboard.component.html',
  styleUrl: './contact-dashboard.component.css',
})
export class ContactDashboardComponent {
  contacts: Array<Contact> = [];

  constructor(private contactService: ContactService, private router: Router) {}
  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.getContacts();
  }

  getContacts(): void {
    this.contactService.getContacts().subscribe((res) => {
      console.log('get contacts =>', res.result);
      this.contacts = res.result;
    });
  }

  navigateToAddContact(): void {
    this.router.navigate(['/add-contact']);
  }
}
