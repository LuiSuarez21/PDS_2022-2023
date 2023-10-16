import { Component, OnInit } from '@angular/core';
import Swal from 'sweetalert2';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.scss']
})
export class UserProfileComponent implements OnInit {
  user: any;
  originalUser: any;
  constructor(private router: Router) { }
  navigateToPage() {
    this.router.navigate(['/login']);
  }
  isCheckboxDisabled: boolean = true;

  ngOnInit(): void {
    // Get the references to the input elements
    const nameInput = document.getElementById('name') as HTMLInputElement;
    const vatInput = document.getElementById('vat') as HTMLInputElement;
    const phoneInput = document.getElementById('phone') as HTMLInputElement;
    const emailInput = document.getElementById('email') as HTMLInputElement;
    const companyInput = document.getElementById('company') as HTMLInputElement;
    const postalCodeInput = document.getElementById('postal-code') as HTMLInputElement;
    const passwordInput = document.getElementById('password') as HTMLInputElement;
    const repeatPasswordInput = document.getElementById('repeat-password') as HTMLInputElement;
    const inactiveInput = document.getElementById('inactive') as HTMLInputElement;

    const humanCheckbox = document.getElementById('human') as HTMLInputElement;
    const addressInput = document.getElementById('address') as HTMLTextAreaElement;
    const cancelButton = document.getElementById('cancel') as HTMLAnchorElement;
    const submitButton = document.getElementById('update') as HTMLButtonElement;

    const form = document.querySelector('form') as HTMLFormElement;
    form.addEventListener('submit', (event) => {
      event.preventDefault();
    });

    cancelButton.addEventListener('click', (event) => {
      event.preventDefault();
      form.reset();
    });

    fetch('https://localhost:7258/api/v1/User/' + Number(localStorage.getItem('user_id')), {
      method: 'GET',
      headers: {
        'Content-Type': 'application/json',
        'Authorization': 'bearer ' + String(localStorage.getItem('token'))
      }
    })
      .then(response => {
        if (!response.ok) {
          // throw new Error('Request failed');
          // console.log('Error:', 'Request failed');
          Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Request failed!',
          });
        }
        return response.json();
      })
      .then(data => {
        console.log(data);
        nameInput.value = data.username;
        vatInput.value = data.vat;
        phoneInput.value = data.phone;
        emailInput.value = data.email;
        if (data.company_id != null && data.company_id != 0) {
          companyInput.value = data.company_id;
        }
        postalCodeInput.value = data.postal_code;
        addressInput.value = data.address;
        if (Boolean(data.inactive)) {
          inactiveInput.checked = false;
        }
        else {
          inactiveInput.checked = true;
        }
        console.log(data);
        this.originalUser = JSON.parse(JSON.stringify(data));
      })
      .catch((error) => {
        console.log('Error:', error);
        Swal.fire({
          icon: 'error',
          title: 'Oops...',
          text: 'Something went wrong!',
        });
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
      
      console.log("aqui");
      console.log(this.originalUser.last_update);
      this.user = {
        id: Number(localStorage.getItem('user_id')),
        username: nameInput.value,
        password: passwordInput.value,
        vat: vatInput.value,
        phone: phoneInput.value,
        address: addressInput.value,
        postal_code: postalCodeInput.value,
        email: emailInput.value,
        company_id: company,
        last_update: this.originalUser.last_update
      };

      console.log(this.user)
      console.log(this.originalUser)
      if (!this.checkForChanges()) {
        Swal.fire({
          icon: 'warning',
          title: 'Warning',
          text: 'No changes',
        });
        return;
      }

      console.log(this.user);

      fetch('https://localhost:7258/api/v1/User/Update', {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': 'bearer ' + String(localStorage.getItem('token'))
        },
        body: JSON.stringify(this.user),
      })
        .then((response) => {
          if (response.ok) {
            console.log('Success!');
            Swal.fire({
              icon: 'success',
              title: 'Success',
              text: 'User successfully updated!',
            });
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

  checkForChanges(): boolean {
    if (this.user && this.originalUser) {
      if (this.user.name != this.originalUser.name) {
        console.log("1")
        return true;
      }
      if (this.user.vat != this.originalUser.vat) {
        console.log("2")
        return true;
      }
      if (this.user.phone != this.originalUser.phone) {
        console.log("3")
        return true;
      }
      if (this.user.email != this.originalUser.email) {
        console.log("4")
        return true;
      }
      if (this.originalUser.company_id == 0 && this.user.company_id != null) {
        console.log("5")
        return true;
      }
      else if (this.originalUser.company_id != 0 && this.user.company_id != this.originalUser.company_id) {
        console.log("6")
        return true;
      }
      if (this.user.postal_code != this.originalUser.postal_code) {
        console.log("7")
        return true;
      }
      if (this.user.address != this.originalUser.address) {
        console.log("8")
        return true;
      }
      // return JSON.stringify(this.user) !== JSON.stringify(this.originalUser);
    }
    return false;
  }
}
