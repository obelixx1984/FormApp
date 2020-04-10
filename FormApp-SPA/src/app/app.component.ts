import { Component, OnInit } from '@angular/core';
import { AuthService } from './_services/auth.service';
import {JwtHelperService} from '@auth0/angular-jwt';
import { Router } from '@angular/router';
import { AlertifyService } from './_services/alertify.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  jwtHelper = new JwtHelperService();

  constructor(private authService: AuthService, private router: Router, private alertify: AlertifyService) {
    if (authService.logowanieIn() === true) {
      this.router.navigate(['/panel']);
    }

    if (authService.logowanieIn() === false) {
      this.alertify.error('Musisz się zalogować !!!');
    }
  }

  ngOnInit() {
    const token = localStorage.getItem('token');
    if (token) {
      this.authService.decodedToken = this.jwtHelper.decodeToken(token);
    }
  }
}
