import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {
  isUserLoggedIn: string;

  constructor(private router: Router) {
    this.isUserLoggedIn = 'false';
  }
  async navigateToPage() {
    await this.router.navigate(['/login']);
    window.location.reload();
  }

  login() {
    this.router.navigate(['/login']);
  }

  logout() {
    // if (!localStorage.getItem('isLoggedIn')) {
    //   localStorage.setItem('isLoggedIn', 'false');
    // }
    // // localStorage.setItem('token', '');
    // // localStorage.setItem('user_id', '');
    // // localStorage.setItem('isLoggedIn', 'false');
    Swal.fire({
      icon: 'success',
      title: 'Sucess'
    }).then(async () => {
      await this.navigateToPage();
    });
    localStorage.setItem('isLoggedIn', 'false');
    // this.router.navigate(['/login']);
    // window.location.reload();
  }

  ngOnInit() {
    if (this.isUserLoggedIn === null) {
      this.isUserLoggedIn = 'false';
    }

    this.isUserLoggedIn = String(localStorage.getItem('isLoggedIn'));

    window.addEventListener('storage', this.onStorageChange.bind(this));
  }

  onStorageChange(event: StorageEvent) {
    if (event.key === 'isLoggedIn') {
      if (this.isUserLoggedIn === null) {
        this.isUserLoggedIn = 'false';
      }

      this.isUserLoggedIn = String(event.newValue);
    }
  }

  ngOnDestroy() {
    window.removeEventListener('storage', this.onStorageChange.bind(this));
  }
}