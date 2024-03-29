import { Component, ElementRef, Input, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  // eslint-disable-next-line @angular-eslint/component-selector
  selector: 'div[app-grid]',
  exportAs:'appGrid',
  templateUrl: './grid.component.html',
  styleUrls: ['./grid.component.scss'],
  encapsulation: ViewEncapsulation.None,
})
export class GridComponent implements OnInit {
  @Input() alignContent: ALIGNCONTENT = 'stretch';
  @Input() alignItems: ALIGNITEMS = 'stretch';
  @Input() container: boolean;
  @Input() direction: DIRECTION = 'row';
  @Input() item:boolean;
  @Input() justify: JUSTIFY = 'flex-start';
  @Input() lg: SIZES = false;
  @Input() md: SIZES = false;
  @Input() sm: SIZES = false;
  @Input() spacing: SPACINGS = 0;
  @Input() wrap: WRAP = 'wrap';
  @Input() xl: SIZES = false;
  @Input() xxl: SIZES = false;
  @Input() xs: SIZES = false;
  @Input() zeroMinWidth = false;

  classArray: string[] = []
  toClass(d:string, value:number|string){
    return d + value;
  }
  toClass2(d:string, value:any){
    value = typeof value === 'boolean' ? 'true' : value;
    return d + value;
  }
  constructor(private elementRef: ElementRef) {
  }

  ngOnInit(): void {
    const arrayClass = [
      this.container?'container-grid':'',
      this.item ? 'item': '',
      this.container && this.spacing !== 0 ? this.toClass('grid-',this.spacing): '',
      this.direction!== 'row' ? this.toClass('direction-',this.direction):  '',
      this.wrap !== 'wrap' ? this.toClass('wrap ',this.wrap ): '',
      this.alignItems !== 'stretch' ? this.toClass('align-items-',this.alignItems): '',
      this.alignContent !== 'stretch' ? this.toClass('align-content-',this.alignContent): '',
      this.justify !== 'flex-start' ? this.toClass('justify-content-',this.justify ): '',
      this.xs  ? this.toClass2('item-xs-', this.xs): '',
      this.sm ? this.toClass2('item-sm-',this.sm): '',
      this.md ? this.toClass2('item-md-',this.md): '',
      this.lg ? this.toClass2('item-lg-',this.lg): '',
      this.xl ? this.toClass2('item-xl-',this.xl): '',
      this.xxl ? this.toClass2('item-xxl-',this.xxl): '',
      this.zeroMinWidth ? 'zeroMinWidth': '',
    ];
    this.classArray = arrayClass.filter(function (el) {
      return el !== "";
    });
    for (const iterator of this.classArray) {
      (this.elementRef.nativeElement as HTMLElement).classList.add(iterator);
    }
  }
}

type ANGKA = 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 10;
type SPACINGS = 0 | ANGKA;
type SIZES = boolean | 'auto' | ANGKA | 11 | 12;
type JUSTIFY =
  | 'flex-start'
  | 'center'
  | 'flex-end'
  | 'space-between'
  | 'space-around'
  | 'space-evenly';
type ALIGNCONTENT =
  | 'stretch'
  | 'center'
  | 'flex-start'
  | 'flex-end'
  | 'space-between'
  | 'space-around';
type ALIGNITEMS = 'flex-start' | 'center' | 'flex-end' | 'stretch' | 'baseline';
type WRAP = 'nowrap' | 'wrap' | 'wrap-reverse';
type DIRECTION = 'row' | 'row-reverse' | 'column' | 'column-reverse';
