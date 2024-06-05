import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ContactService } from '../../services/contact/contact.service';

@Component({
  selector: 'app-add-contact',
  templateUrl: './add-contact.component.html',
  styleUrl: './add-contact.component.css',
})
export class AddContactComponent {
  form: FormGroup;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private contactService: ContactService
  ) {
    this.form = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      phoneNumber: ['', Validators.required],
    });
  }

  onSubmit() {
    if (this.form.valid) {
      console.log('Form Submitted', this.form.value);
      this.contactService.addContact(this.form.value).subscribe((res) => {
        console.log('add contact res =>', res);
        if (res.success) this.navigateToContactDashboard();
        else alert(res.message);
      });
    } else {
      console.log('Form not valid');
    }
  }

  navigateToContactDashboard(): void {
    this.router.navigate(['/']);
  }
}
