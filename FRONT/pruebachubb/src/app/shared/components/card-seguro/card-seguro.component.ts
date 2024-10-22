import { Component, Input, OnChanges, OnDestroy, SimpleChanges } from '@angular/core';
import { ResponseSeguroEdad } from '../../../cliente/interfaces/response/genericResponse';

@Component({
  selector: 'app-card-seguro',
  templateUrl: './card-seguro.component.html',
  styleUrl: './card-seguro.component.css'
})
export class CardSeguroComponent  {

  @Input() seguros: ResponseSeguroEdad[] = [];
  

}
