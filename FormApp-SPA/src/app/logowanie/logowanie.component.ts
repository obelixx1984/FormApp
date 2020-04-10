import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { Router } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-logowanie',
  templateUrl: './logowanie.component.html',
  styleUrls: ['./logowanie.component.css']
})
export class LogowanieComponent implements OnInit {
  model: any = {};

  constructor(private authService: AuthService, private alertify: AlertifyService,
              private router: Router, private title: Title) { }

  ngOnInit() {
    // dodanie tytułu strony
    this.title.setTitle('Panel logowania');
  }

  logowanie() {
    this.authService.logowanie(this.model).subscribe(next => {
      this.alertify.success('Zostałeś zalogowany !!!');
      setTimeout(() => {
        this.router.navigate(['/panel']);
      }, 1000);
    }, error => {
      this.alertify.error('Błędna nazwa użytkownika lub hasło !!!');
    });
  }

}
