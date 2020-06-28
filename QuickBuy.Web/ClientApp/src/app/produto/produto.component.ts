import { Component, OnInit } from '@angular/core';
import { Produto } from '../modelo/produto';
import { ProdutoServico } from '../servicos/produto/produto.servico';

@Component({
  selector: 'app-produto',
  templateUrl: './produto.component.html',
  styleUrls: ['./produto.component.css']
})

export class ProdutoComponent implements OnInit {

  public produto: Produto;

  constructor(private produtoservico: ProdutoServico) {

  }

  ngOnInit(): void {
    this.produto = new Produto();
  }

  public cadastrar() {
    this.produtoservico.cadastrar(this.produto)
      .subscribe(
        produtoJson => {
          console.log(produtoJson);
        },
        e => {
          console.log(e.error);
        }
      );
  }

  /*public nome: string;

  public getNome(): string {
    return "Samsumg";
  } */
}
