import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { Router } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-panel',
  templateUrl: './panel.component.html',
  styleUrls: ['./panel.component.css']
})
export class PanelComponent implements OnInit {

  constructor(private authService: AuthService, private alertify: AlertifyService,
              private router: Router, private title: Title) { }

  ngOnInit() {
    // dodanie tytułu strony
    this.title.setTitle('Panel użytkownika');
  }

  logowanieIn() {
    return this.authService.logowanieIn();
  }

  logowanieOut() {
    localStorage.removeItem('token');
    this.alertify.warning('Wylogowano !!!');
    this.router.navigate(['/home']);
  }

}
