import { Component, OnInit } from '@angular/core';
import Swal from 'sweetalert2';
import { Router } from '@angular/router';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
  constructor(private router: Router) { }
  navigateToPage() {
    this.router.navigate(['/login']);
  }

  ngOnInit(): void {
    const nameInput = document.getElementById('name') as HTMLInputElement;
    const vatInput = document.getElementById('vat') as HTMLInputElement;
    const phoneInput = document.getElementById('phone') as HTMLInputElement;
    const emailInput = document.getElementById('email') as HTMLInputElement;
    const companyInput = document.getElementById('company') as HTMLInputElement;
    const postalCodeInput = document.getElementById('postal-code') as HTMLInputElement;
    const passwordInput = document.getElementById('password') as HTMLInputElement;
    const repeatPasswordInput = document.getElementById('repeat-password') as HTMLInputElement;
    const humanCheckbox = document.getElementById('human') as HTMLInputElement;
    const addressInput = document.getElementById('address') as HTMLTextAreaElement;
    const cancelButton = document.getElementById('cancel') as HTMLAnchorElement;
    const submitButton = document.getElementById('create') as HTMLButtonElement;

    const form = document.querySelector('form') as HTMLFormElement;
    form.addEventListener('submit', (event) => {
      event.preventDefault();
    });

    cancelButton.addEventListener('click', (event) => {
      event.preventDefault();
      form.reset();
    });

    submitButton.addEventListener('click', (event) => {
      event.preventDefault();

      if (repeatPasswordInput.value != passwordInput.value) {
        Swal.fire({
          icon: 'error',
          title: 'Oops...',
          text: 'Password does not match!',
        });
        return;
      }

      if (!humanCheckbox.checked) {
        Swal.fire({
          icon: 'error',
          title: 'Oops...',
          text: 'Are you not human? :o',
        });
        return;
      }

      var company;
      if (companyInput.value == null || companyInput.value == "") {
        company = null;
      } else {
        company = companyInput.value;
      }

      var user = {
        username: nameInput.value,
        password: passwordInput.value,
        vat: vatInput.value,
        phone: phoneInput.value,
        address: addressInput.value,
        postal_code: postalCodeInput.value,
        email: emailInput.value,
        company_id: company
      };

      console.log(user);
      fetch('https://localhost:7258/api/v1/User/new', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(user),
      })
        .then((response) => {
          if (response.ok) {
            console.log('Sucess!');
            Swal.fire({
              icon: 'success',
              title: 'Sucess',
              text: 'User sucessfully created!',
            });
            form.reset();
            this.navigateToPage();
          } else {
            console.log(response);
            Swal.fire({
              icon: 'error',
              title: 'Oops...',
              text: 'Something went wrong!',
            });
          }
        })
        .catch((error) => {
          console.log('Error:', error);
          Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Something went wrong!',
          });
        });
    });
  }
}
