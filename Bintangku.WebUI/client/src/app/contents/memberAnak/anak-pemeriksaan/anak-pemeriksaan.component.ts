import { Component, OnInit } from '@angular/core';
import {
  DateAdapter,
  MAT_DATE_FORMATS,
  MAT_DATE_LOCALE,
} from '@angular/material/core';
import { MomentDateAdapter } from '@angular/material-moment-adapter';
import { MatDialog } from '@angular/material/dialog';
import { BeratBadanComponent } from '../dialogs/berat-badan/berat-badan.component';
import { GpphComponent } from '../dialogs/gpph/gpph.component';
import { KpspComponent } from '../dialogs/kpsp/kpsp.component';
import { LingkarKepalaComponent } from '../dialogs/lingkar-kepala/lingkar-kepala.component';
import { TinggiBadanComponent } from '../dialogs/tinggi-badan/tinggi-badan.component';
import {
  animate,
  state,
  style,
  transition,
  trigger,
} from '@angular/animations';
import { DomSanitizer } from '@angular/platform-browser';
import { MatIconRegistry } from '@angular/material/icon';
import { ImtComponent } from '../dialogs/imt/imt.component';
import { PRIMARY_OUTLET, Router, UrlSegment, UrlSegmentGroup, UrlTree } from '@angular/router';
import { LingkatKepalaService } from 'src/app/_services/kesehatan-fisik/lingkat-kepala.service';
import { LingkarKepala } from 'src/app/_models/kesehatan-fisik/lingkar-kepala';

const ADDPENCIL = `<svg width="17" height="17" viewBox="0 0 17 17" fill="none" xmlns="http://www.w3.org/2000/svg">
<path d="M16.2501 4.83341C16.5834 4.50008 16.5834 4.00008 16.2501 3.66675L14.3334 1.75008C14.0001 1.41675 13.5001 1.41675 13.1667 1.75008L11.6667 3.25008L14.8334 6.41675L16.2501 4.83341ZM1.50008 13.3334V16.5001H4.66675L13.8334 7.25008L10.7501 4.08341L1.50008 13.3334ZM4.83341 0.666748V3.16675H7.33341V4.83341H4.83341V7.33341H3.16675V4.83341H0.666748V3.16675H3.16675V0.666748H4.83341Z" fill="#003466"/>
</svg>`;

export const MY_FORMATS = {
  parse: {
    dateInput: 'LL',
  },
  display: {
    dateInput: 'YYYY-MM-DD',
    monthYearLabel: 'YYYY',
    dateA11yLabel: 'LL',
    monthYearA11yLabel: 'YYYY',
  },
};

@Component({
  selector: 'app-anak-pemeriksaan',
  templateUrl: './anak-pemeriksaan.component.html',
  styleUrls: ['./anak-pemeriksaan.component.css'],
  providers: [
    // `MomentDateAdapter` can be automatically provided by importing `MomentDateModule` in your
    // application's root module. We provide it at the component level here, due to limitations of
    // our example generation script.
    {
      provide: DateAdapter,
      useClass: MomentDateAdapter,
      deps: [MAT_DATE_LOCALE],
    },

    { provide: MAT_DATE_FORMATS, useValue: MY_FORMATS },
  ],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({ height: '0px', minHeight: '0' })),
      state('expanded', style({ height: '*' })),
      transition(
        'expanded <=> collapsed',
        animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')
      ),
    ]),
  ],
})
export class AnakPemeriksaanComponent implements OnInit {
  dataSource = ELEMENT_DATA;
  columnsToDisplay = ['name', 'position'];
  expandedElement: PeriodicElement | null;
  loading = false;
  idAnak:number;

  dataLingkarKepala = {
    dataSource:[],
    columnsToDisplay: [ // field dari response database
      'no',
      'lingkarKepala',
      'kurva',
      'klasifikasi',
      'tindakan',
    ],
    stringDisplay: { // key = columns display : value = yang di tampilkan di <th> value </th>
      no: 'No.',
      lingkarKepala: 'Lingkar Kepala',
      kurva: 'Kurva',
      klasifikasi: 'Klasifikasi',
      tindakan: 'Tindakan',
    },
  }


  detail = [
    this.dataLingkarKepala,
  ];
  constructor(
    public dialog: MatDialog,
    iconRegistry: MatIconRegistry,
    sanitizer: DomSanitizer,
    private router: Router,
    private lkService : LingkatKepalaService
  ) {
    iconRegistry.addSvgIconLiteral(
      'pencil-add',
      sanitizer.bypassSecurityTrustHtml(ADDPENCIL)
    );
  }
  ngOnInit(): void{
    const tree: UrlTree = this.router.parseUrl(this.router.url);
    const g: UrlSegmentGroup = tree.root.children[PRIMARY_OUTLET];
    const s: UrlSegment[] = g.segments;
    // ['anak-members','35','jadwal-imunisasi']
    this.idAnak = +s[1].path;
  }
  openModal(index: number) {
    // masukkan method masing-2 open modal
    const data = [
      this.openLingkarKepala(this.idAnak),
    ];
    data[index]
  }

  showTable(index:number){
    // masukkan method masing-2 pemeriksaan
    const getData = [
      this.getLingkarKepala()
    ]
    getData[index]
  }

  openBeratBadan() {
    const dialogRef = this.dialog.open(BeratBadanComponent);

    dialogRef.afterClosed().subscribe((result) => {
      console.log(`Dialog result: ${result}`);
    });
  }

  openTinggiBadan() {
    const dialogRef = this.dialog.open(TinggiBadanComponent);

    dialogRef.afterClosed().subscribe((result) => {
      console.log(`Dialog result: ${result}`);
    });
  }

  openLingkarKepala(id:number) {
    const dialogRef = this.dialog.open(LingkarKepalaComponent,
      {
        width: '1200px',
        data: {id}
      }
      );

    dialogRef.afterClosed().subscribe((result) => {
      console.log(result)
      if (result === 'update'){
        this.dataLingkarKepala.dataSource.length = 0;
        this.getLingkarKepala()
      }
    });
  }

  openKpsp() {
    const dialogRef = this.dialog.open(KpspComponent);

    dialogRef.afterClosed().subscribe((result) => {
      console.log(`Dialog result: ${result}`);
    });
  }

  openGpph() {
    const dialogRef = this.dialog.open(GpphComponent);

    dialogRef.afterClosed().subscribe((result) => {
      console.log(result);
    });
  }

  getLingkarKepala(){
    if(this.dataLingkarKepala.dataSource.length) return

    this.lkService.getLingkarKepala(this.idAnak).subscribe(
      (lingkar)=> {this.dataLingkarKepala.dataSource = lingkar}
    )
  }
}

export interface PeriodicElement {
  name: string;
  position: number;
}
const ELEMENT_DATA: PeriodicElement[] = [
  {
    position: 0,
    name: 'Lingkar kepala',
  },
  {
    position: 1,
    name: 'Status gizi(BB/TB)',
  },
  {
    position: 2,
    name: 'Status gizi(IMT/U)',
  },
  {
    position: 3,
    name: 'Status gizi(IP/TB)',
  },
  {
    position: 4,
    name: 'KPSP',
  },
  {
    position: 5,
    name: 'Daya dengar',
  },
  {
    position: 6,
    name: 'Daya lihat',
  },
  {
    position: 7,
    name: 'Pemeriksaan GPPH',
  },
  {
    position: 8,
    name: 'Pemeriksaan KMPE',
  },
  {
    position: 9,
    name: 'Pemeriksaan M-CHAT',
  },
];
