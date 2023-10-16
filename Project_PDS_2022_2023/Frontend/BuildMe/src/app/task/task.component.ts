import { Component, OnInit } from '@angular/core';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.scss'],
})
export class TaskComponent implements OnInit {
  cities: any[] = [];
  selectedCity: any;

  ngOnInit(): void {
    this.fetchData();
    const descriptionInput = document.getElementById('description') as HTMLInputElement;
    const startDateInput = document.getElementById('start-date') as HTMLInputElement;
    const endDateInput = document.getElementById('end-date') as HTMLInputElement;
    const dateBiddingStartInput = document.getElementById('date-bidding-start') as HTMLInputElement;
    const dateBiddingEndInput = document.getElementById('date-bidding-end') as HTMLInputElement;

    const humanCheckbox = document.getElementById('human') as HTMLInputElement;
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

      if (!humanCheckbox.checked) {
        Swal.fire({
          icon: 'error',
          title: 'Oops...',
          text: 'Are you not human? :o',
        });
        return;
      }
      console.log('Selected city:', this.selectedCity);
      var task = {
        user_id: String(localStorage.getItem('user_id')),
        description: descriptionInput.value,
        city_id: Number(this.selectedCity),
        date_start: startDateInput.value,
        date_end: endDateInput.value,
        date_bidding_start: dateBiddingStartInput.value,
        date_bidding_end: dateBiddingEndInput.value,
        task_status_id: 1
      };

      console.log(task);
      fetch('https://localhost:7258/api/v1/Task/new', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': 'bearer ' + String(localStorage.getItem('token'))
        },
        body: JSON.stringify(task),
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
          } else if (response.status === 401) {
            console.log('Unauthorized!');
            Swal.fire({
              icon: 'error',
              title: 'Oops...',
              text: 'Unauthorized access!',
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

  fetchData() {
    fetch('https://localhost:7258/api/v1/City/all', {
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
        this.cities = data;
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
