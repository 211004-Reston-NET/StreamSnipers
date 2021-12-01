import { DOCUMENT } from '@angular/common';
import { compileNgModuleDeclarationExpression } from '@angular/compiler/src/render3/r3_module_compiler';
import { Component, Inject, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { ConnectableObservable } from 'rxjs';
import { WebAPIService } from 'src/app/services/web-api.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(public auth0:AuthService, @Inject(DOCUMENT) public document: Document) { }

  ngOnInit(): void {
  }

  login()
  {
    this.auth0.loginWithRedirect();
  }
}
