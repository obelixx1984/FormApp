import { BrowserModule, Title } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { ShowHidePasswordModule } from 'ngx-show-hide-password';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatDividerModule } from '@angular/material/divider';
import { MatToolbarModule } from '@angular/material/toolbar';

import { AppComponent } from './app.component';
import { LogowanieComponent } from './logowanie/logowanie.component';
import { AuthService } from './_services/auth.service';
import { PanelComponent } from './panel/panel.component';
import { RouterModule } from '@angular/router';
import { appRoutes } from './routes';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HeaderComponent } from './shared/components/header/header.component';
import { FooterComponent } from './shared/components/footer/footer.component';
import { SidebarComponent } from './shared/components/sidebar/sidebar.component';
import { DefaultComponent } from './shared/components/default/default.component';

@NgModule({
   declarations: [
      AppComponent,
      LogowanieComponent,
      PanelComponent,
      HeaderComponent,
      FooterComponent,
      SidebarComponent,
      DefaultComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      TabsModule.forRoot(),
      FormsModule,
      RouterModule.forRoot(appRoutes),
      ShowHidePasswordModule,
      BrowserAnimationsModule,
      MatSidenavModule,
      MatDividerModule,
      MatToolbarModule
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
