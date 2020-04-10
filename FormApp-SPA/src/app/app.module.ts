import { BrowserModule, Title } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { ShowHidePasswordModule } from 'ngx-show-hide-password';

import { AppComponent } from './app.component';
import { LogowanieComponent } from './logowanie/logowanie.component';
import { AuthService } from './_services/auth.service';
import { PanelComponent } from './panel/panel.component';
import { RouterModule } from '@angular/router';
import { appRoutes } from './routes';

@NgModule({
   declarations: [
      AppComponent,
      LogowanieComponent,
      PanelComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      TabsModule.forRoot(),
      FormsModule,
      RouterModule.forRoot(appRoutes),
      ShowHidePasswordModule
   ],
   providers: [
      AuthService,
      Title
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
