import { Component, OnInit } from '@angular/core';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-task-dashboard',
  templateUrl: './task-dashboard.component.html',
  styleUrls: ['./task-dashboard.component.scss']
})
export class TaskDashboardComponent implements OnInit {
  tasks: any[] = [];

  ngOnInit() {
    this.fetchData();
  }

  fetchData() {
    fetch('https://localhost:7258/api/v1/Task/userTasks/' + Number(localStorage.getItem('user_id')), {
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
        this.tasks = data;
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
