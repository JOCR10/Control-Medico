import { Component, OnInit } from '@angular/core';
import { TokenStorageService } from './_services/token-storage.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  private rol: string;
  isLoggedIn = false;
  showAdminBoard = false;
  showModeratorBoard = false;
  username: string;

  constructor(private router:Router, private tokenStorageService: TokenStorageService) { }

  ngOnInit() {
    this.isLoggedIn = !!this.tokenStorageService.getToken();

    if (this.isLoggedIn) {
      const user = this.tokenStorageService.getUser();
      this.rol = user.rol;

      this.showAdminBoard = this.rol === 'Admin';
      this.showModeratorBoard = this.rol === ('Consulta');

      this.username = user.CodUsuario;
    }
  }

  logout() {
    this.tokenStorageService.signOut();
    this.router.navigate(["/login"]); 
  }
}