import { Component } from '@angular/core';
import Swal from 'sweetalert2';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})

export class LoginComponent {
  constructor(private router: Router) { }
  async navigateToPage() {
    await this.router.navigate(['/home']);
    window.location.reload();
  }
  username: string = '';
  password: string = '';
  errorMessage: string = '';

  login() {
    const user = {
      username: this.username,
      password: this.password,
    };

    fetch('https://localhost:7258/api/v1/User/login', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(user),
    })
      .then((response: any) => {
        if (response.ok) {
          console.log('Sucess!');
          Swal.fire({

            icon: 'success',
            title: 'Sucess'
          }).then(async () => {
            await this.navigateToPage();
          });
          console.log(response);
          return response.text();
        } else {
          console.log(response);
          Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Something went wrong!',
          });
        }
      })
      .then(async data => {
        console.log(data);
        const datajson = JSON.parse(data);
        localStorage.setItem('token', datajson.token);
        localStorage.setItem('user_id', datajson.user_id);
        localStorage.setItem('isLoggedIn', 'true');
        console.log(localStorage.getItem('token'));
        console.log(localStorage.getItem('user_id'));
        console.log(localStorage.getItem('isLoggedIn'));
        // window.location.reload();

      })
      .catch((error) => {
        console.log('Error:', error);
        Swal.fire({
          icon: 'error',
          title: 'Oops...',
          text: 'Something went wrong!',
        });
      });
  }
}
