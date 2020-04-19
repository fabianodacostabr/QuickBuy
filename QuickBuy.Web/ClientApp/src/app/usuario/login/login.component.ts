import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Usuario } from '../../modelo/usuario';
import { Session } from 'protractor';
import { UsuarioServico } from '../../servicos/usuario/usuario.servico';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'] 
})

export class LoginComponent implements OnInit {

  public usuario;
  public returnUrl: string;
  public mensagem: string;
  public _ativar_spinner: boolean;

  constructor(private router: Router, private activatedRouter: ActivatedRoute, private usuarioServico: UsuarioServico) {
    
  }

  ngOnInit(): void {
    this.returnUrl = this.activatedRouter.snapshot.queryParams['returnUrl'];
    this.usuario = new Usuario();     
  }


  entrar() {

    this._ativar_spinner = true;

    //localStorage.setItem("usuario-autenticado", "0");
    /*if (this.usuario.email == "teste@teste.com.br" && this.usuario.senha == "1234") {
      sessionStorage.setItem("usuario-autenticado", "1");
      this.router.navigate([this.returnUrl]);*/
    this.usuarioServico.verificarUsuario(this.usuario).subscribe
      (
        usuario_json => {

          this.usuarioServico.usuario = usuario_json;

          //console.log(data);
          /*var usuarioRetorno: Usuario;
          usuarioRetorno = data;
          sessionStorage.setItem("usuario-autenticado", "1");
          sessionStorage.setItem("usuario-email", usuarioRetorno.email);*/

          if (this.returnUrl == null) {
            this.router.navigate(["/"]);
          }
          else {
            this.router.navigate([this.returnUrl]);
          }
          
      },
      err => {
        //console.log(err.error);
        this.mensagem = err.error;
        this._ativar_spinner = false;
      }
    );
  }


}
