import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'arrow'
})
export class ArrowPipe implements PipeTransform {

  transform(value: unknown, ...args: unknown[]): unknown {
    return value + '->';
  }

}
