import { Component, OnInit } from '@angular/core';
import {
  DateAdapter,
  MAT_DATE_FORMATS,
  MAT_DATE_LOCALE,
} from '@angular/material/core';
import { MomentDateAdapter } from '@angular/material-moment-adapter';
import { MatDialog } from '@angular/material/dialog';
import { LingkarKepalaComponent } from '../dialogs/lingkar-kepala/lingkar-kepala.component';
import {
  animate,
  state,
  style,
  transition,
  trigger,
} from '@angular/animations';
import { DomSanitizer } from '@angular/platform-browser';
import { MatIconRegistry } from '@angular/material/icon';
import {
  PRIMARY_OUTLET,
  Router,
  UrlSegment,
  UrlSegmentGroup,
  UrlTree,
} from '@angular/router';
import { StatusGiziBbTbComponent } from '../dialogs/status-gizi-bb-tb/status-gizi-bb-tb.component';
import { StatusGiziImtUComponent } from '../dialogs/status-gizi-imt-u/status-gizi-imt-u.component';
import { PemeriksaanKesehatanService } from 'src/app/_services/pemeriksaan-kesehatan.service';
import { StatusGiziTbUComponent } from '../dialogs/status-gizi-tb-u/status-gizi-tb-u.component';
import { DayaLihatComponent } from '../dialogs/daya-lihat/daya-lihat.component';
import { KpspComponent } from '../dialogs/kpsp/kpsp.component';
import { GpphComponent } from '../dialogs/gpph/gpph.component';
import { KmpeComponent } from '../dialogs/kmpe/kmpe.component';
import { MchatComponent } from '../dialogs/mchat/mchat.component';

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
  idAnak: number;
  width: string = '1200px';

  dataLingkarKepala = {
    dataSource: [],
    columnsToDisplay: [
      'no',
      'lingkarKepala',
      'kurva',
      'klasifikasi',
      'tindakan',
    ],
    stringDisplay: {
      no: 'No.',
      lingkarKepala: 'Lingkar Kepala',
      kurva: 'Kurva',
      klasifikasi: 'Klasifikasi',
      tindakan: 'Tindakan',
    },
  };

  dataStatusGiziBbTb = {
    dataSource: [],
    columnsToDisplay: [
      'no',
      'beratBadan',
      'tinggiBadan',
      'zCode',
      'statusGizi',
      'tindakan',
    ],
    stringDisplay: {
      no: 'No.',
      beratBadan: 'Berat Badan',
      tinggiBadan: 'Tinggi Badan',
      zCode: 'Z-Code',
      statusGizi: 'Status Gizi',
      tindakan: 'Tindakan',
    },
  };

  dataStatusGiziImtU = {
    dataSource: [],
    columnsToDisplay: [
      'no',
      'beratBadan',
      'tinggiBadan',
      'umur',
      'imt',
      'zCode',
      'statusGizi',
      'tindakan',
    ],
    stringDisplay: {
      no: 'No',
      beratBadan: 'Berat Badan',
      tinggiBadan: 'Tinggi Badan',
      umur: 'Umur',
      imt: 'IMT',
      zCode: 'Z-Code',
      statusGizi: 'Status Gizi',
      tindakan: 'Tindakan',
    },
  };

  dataStatusGiziTbU = {
    dataSource: [],
    columnsToDisplay: [
      'no',
      'tinggiBadan',
      'indeksPanjang',
      'zCode',
      'statusGizi',
      'tindakan',
    ],
    stringDisplay: {
      no: 'No',
      tinggiBadan: 'Tinggi Badan',
      zCode: 'Z-Code',
      statusGizi: 'Status Gizi',
      tindakan: 'Tindakan',
    },
  };

  dataKpsp = {
    dataSource: [],
    columnsToDisplay: [
      'no',
      'tinggiBadan',
      'indeksPanjang',
      'zCode',
      'statusGizi',
      'tindakan',
    ],
    stringDisplay: {
      no: 'No',
      tinggiBadan: 'Tinggi Badan',
      zCode: 'Z-Code',
      statusGizi: 'Status Gizi',
      tindakan: 'Tindakan',
    },
  };

  dataDayaDengar = {
    dataSource: [],
    columnsToDisplay: [
      'no',
      'mataKanan',
      'mataKiri',
      'interpretasi',
      'intervensi',
    ],
    stringDisplay: {
      no: 'No',
      mataKanan: 'Mata Kanan',
      mataKiri: 'Mata Kiri',
      interpretasi: 'Interpretasi',
      intervensi: 'Intervensi',
    },
  };

  dataTesDayaLihat = {
    dataSource: [],
    columnsToDisplay: [
      'no',
      'mataKanan',
      'mataKiri',
      'interpretasi',
      'intervensi',
    ],
    stringDisplay: {
      no: 'No',
      mataKanan: 'Mata Kanan',
      mataKiri: 'Mata Kiri',
      interpretasi: 'Interpretasi',
      intervensi: 'Intervensi',
    },
  };

  dataGpph = {
    dataSource: [],
    columnsToDisplay: [
      'no',
      'point',
      'interpretasi',
      'intervensi',
      'question1',
      'question2',
      'question3',
      'question4',
      'question5',
      'question6',
      'question7',
      'question8',
      'questoin9',
      'question10',
    ],
    stringDisplay: {
      no: 'No',
      point: 'Point',
      interpretasi: 'Interpretasi',
      intervensi: 'Intervensi',
      question1: 'Question 1',
      question2: 'Question 2',
      question3: 'Question 3',
      question4: 'Question 4',
      question5: 'Question 5',
      question6: 'Question 6',
      question7: 'Question 7',
      question8: 'Question 8',
      question9: 'Question 9',
      question10: 'Question 10',
    },
  };

  dataKmpe = {
    dataSource: [],
    columnsToDisplay: [
      'no',
      'jumlahYa',
      'interpretasi',
      'intervensi',
      'question1',
      'question2',
      'question3',
      'question4',
      'question5',
      'question6',
      'question7',
      'question8',
      'questoin9',
      'question10',
      'question11',
      'question12',
      'question13',
      'question14',
    ],
    stringDisplay: {
      no: 'No',
      jumlahYa: 'Jumlah Ya',
      interpretasi: 'Interpretasi',
      intervensi: 'Intervensi',
      question1: 'Question 1',
      question2: 'Question 2',
      question3: 'Question 3',
      question4: 'Question 4',
      question5: 'Question 5',
      question6: 'Question 6',
      question7: 'Question 7',
      question8: 'Question 8',
      question9: 'Question 9',
      question10: 'Question 10',
      question11: 'Question 11',
      question12: 'Question 12',
      question13: 'Question 13',
      question14: 'Question 14',
    },
  };

  // "question1": true,
  //       "question2": true,
  //       "question3": true,
  //       "question4": true,
  //       "question5": true,
  //       "question6": true,
  //       "question7": true,
  //       "question8": true,
  //       "question9": true,
  //       "question10": true,
  //       "question11": true,
  //       "question12": true,
  //       "question13": true,
  //       "question14": true,
  //       "question15": true,
  //       "question16": true,
  //       "question17": true,
  //       "question18": true,
  //       "question19": true,
  //       "question20": true,
  //       "question21": true,
  //       "question22": true,
  //       "question23": true,
  //       "totalCriticalQuestionYes": 6,
  //       "totalCriticalQuestionNo": 0,
  //       "totalQuestionYes": 23,
  //       "totalQuestionNo": 0,
  //       "interpretasi": "Normal",
  //       "intervensi": "Tidak Perlu Rujuk Kerumah Sakit",
  dataMchat = {
    dataSource: [],
    columnsToDisplay: [
      'no',
      'question1',
      'question2',
      'question3',
      'question4',
      'question5',
      'question6',
      'question7',
      'question8',
      'questoin9',
      'question10',
      'question11',
      'question12',
      'question13',
      'question14',
      'question15',
      'question16',
      'question17',
      'question18',
      'question19',
      'question20',
      'question21',
      'question22',
      'question23',
      'totalCriticalQuestionYes',
      'totalCriticalQuestionNo',
      'totalQuestionYes',
      'totalQuestionNo',
      'interpretasi',
      'intervensi',
    ],
    stringDisplay: {
      no: 'No',
      question1: 'Question 1',
      question2: 'Question 2',
      question3: 'Question 3',
      question4: 'Question 4',
      question5: 'Question 5',
      question6: 'Question 6',
      question7: 'Question 7',
      question8: 'Question 8',
      question9: 'Question 9',
      question10: 'Question 10',
      question11: 'Question 11',
      question12: 'Question 12',
      question13: 'Question 13',
      question14: 'Question 14',
      totalCriticalQuestionYes: 'Total Critical Question Yes',
      totalCriticalQuestionNo: 'Total Critical Question No',
      totalQuestionYes: 'Total Question Yes',
      totalQuestionNo: 'Total Question No',
      interpretasi: 'Interpretasi',
      intervensi: 'Intervensi',
    },
  };

  /**
   * List data pemeriksaan kesehatan to display
   */
  detail = [
    this.dataLingkarKepala,
    this.dataStatusGiziBbTb,
    this.dataStatusGiziImtU,
    this.dataStatusGiziTbU,
    this.dataKpsp,
    this.dataDayaDengar,
    this.dataTesDayaLihat,
    this.dataGpph,
    this.dataKmpe,
    this.dataMchat,
  ];

  constructor(
    public dialog: MatDialog,
    iconRegistry: MatIconRegistry,
    sanitizer: DomSanitizer,
    private router: Router,
    private _pemeriksaanService: PemeriksaanKesehatanService
  ) {
    iconRegistry.addSvgIconLiteral(
      'pencil-add',
      sanitizer.bypassSecurityTrustHtml(ADDPENCIL)
    );
  }

  ngOnInit(): void {
    const tree: UrlTree = this.router.parseUrl(this.router.url);
    const g: UrlSegmentGroup = tree.root.children[PRIMARY_OUTLET];
    const s: UrlSegment[] = g.segments;
    this.idAnak = +s[1].path;
  }

  /**
   * Method for open modal based on the index position
   * @param index Index of ELEMENT_DATA
   */
  openModal(index: number) {
    switch (index) {
      case 0:
        this.openLingkarKepala(this.idAnak);
        break;
      case 1:
        this.openStatusGiziBbTb(this.idAnak);
        break;
      case 2:
        this.openStatusGiziImtU(this.idAnak);
        break;
      case 3:
        this.openStatusGiziTbU(this.idAnak);
        break;
      case 6:
        this.openDayaLihat(this.idAnak);
        break;
      case 7:
        this.openGpph(this.idAnak);
        break;
      case 8:
        this.openKmpe(this.idAnak);
        break;
      case 9:
        this.openMchat(this.idAnak);
        break;
    }
  }

  /**
   * Method to open hasil pemeriksaan
   * @param index Index of ELEMENT_DATA
   */
  showTable(index: number) {
    switch (index) {
      case 0:
        this.getLingkarKepala();
        break;
      case 1:
        this.getStatusGiziBbTb();
        break;
      case 2:
        this.getStatusGiziImtU();
        break;
      case 3:
        this.getStatusGiziTbU();
        break;
      case 6:
        this.getTesDataLihat();
        break;
      case 7:
        this.getGpph();
        break;
      case 8:
        this.getKmpe();
        break;
      case 9:
        this.getMchat();
        break;
    }
  }

  /**
   * Method to open lingkar kepala component modal
   * @param id dataAnakId
   */
  openLingkarKepala(id: number) {
    const dialogRef = this.dialog.open(LingkarKepalaComponent, {
      width: this.width,
      data: { id },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result === 'update') {
        this.dataLingkarKepala.dataSource.length = 0;
        this.getLingkarKepala();
      }
    });
  }

  /**
   * Method to get result of pemeriksaan lingkar kepala
   * @returns Hasil pemeriksaan lingkar kepala
   */
  getLingkarKepala() {
    if (this.dataLingkarKepala.dataSource.length) return;

    this._pemeriksaanService
      .getLingkarKepala(this.idAnak)
      .subscribe((lingkar) => {
        this.dataLingkarKepala.dataSource = lingkar;
      });
  }

  /**
   * Open pemeriksaan status gizi berat badan menurut tinggi badan
   * @param id dataAnakId
   */
  openStatusGiziBbTb(id: number) {
    const dialogRef = this.dialog.open(StatusGiziBbTbComponent, {
      width: this.width,
      data: { id },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result === 'update') {
        this.dataStatusGiziBbTb.dataSource.length = 0;
        this.getStatusGiziBbTb();
      }
    });
  }

  /**
   * Get hasil pemeriksaan status gizi berat badan menurut tinggi badan
   * @returns List hasil pemeriksaan
   */
  getStatusGiziBbTb() {
    if (this.dataStatusGiziBbTb.dataSource.length) return;

    this._pemeriksaanService.getGiziBbTb(this.idAnak).subscribe((result) => {
      this.dataStatusGiziBbTb.dataSource = result;
    });
  }

  /**
   * Method to open dialog for pemeriksaan status gizi IMT berdasarkan umur
   * @param id dataAnakId
   */
  openStatusGiziImtU(id: number) {
    const dialogRef = this.dialog.open(StatusGiziImtUComponent, {
      width: this.width,
      data: { id },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result === 'update') {
        this.dataStatusGiziImtU.dataSource.length = 0;
        this.getStatusGiziImtU();
      }
    });
  }

  /**
   *
   * @returns
   */
  getStatusGiziImtU() {
    if (this.dataStatusGiziImtU.dataSource.length) return;

    this._pemeriksaanService.getGiziImtU(this.idAnak).subscribe((result) => {
      this.dataStatusGiziImtU.dataSource = result;
    });
  }

  /**
   *
   * @param id
   */
  openStatusGiziTbU(id: number) {
    const dialogRef = this.dialog.open(StatusGiziTbUComponent, {
      width: this.width,
      data: { id },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result === 'update') {
        this.dataStatusGiziTbU.dataSource.length = 0;
        this.getStatusGiziTbU();
      }
    });
  }

  /**
   *
   * @returns
   */
  getStatusGiziTbU() {
    if (this.dataStatusGiziTbU.dataSource.length) return;

    this._pemeriksaanService.getGiziIpTb(this.idAnak).subscribe((result) => {
      this.dataStatusGiziTbU.dataSource = result;
    });
  }

  /**
   *
   * @param id
   */
  openDayaLihat(id: number) {
    const dialogRef = this.dialog.open(DayaLihatComponent, {
      width: this.width,
      data: { id },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result === 'update') {
        this.dataTesDayaLihat.dataSource.length = 0;
        this.getTesDataLihat();
      }
    });
  }

  /**
   *
   * @returns
   */
  getTesDataLihat() {
    if (this.dataTesDayaLihat.dataSource.length) return;

    this._pemeriksaanService.getDayaLihat(this.idAnak).subscribe((result) => {
      this.dataTesDayaLihat.dataSource = result;
    });
  }

  /**
   *
   * @param id
   */
  openGpph(id: number) {
    const dialogRef = this.dialog.open(GpphComponent, {
      width: this.width,
      data: { id },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result === 'update') {
        this.dataKpsp.dataSource.length = 0;
        this.getGpph();
      }
    });
  }

  /**
   *
   * @returns
   */
  getGpph() {
    if (this.dataKpsp.dataSource.length) return;

    this._pemeriksaanService
      .getPemeriksaanGpph(this.idAnak)
      .subscribe((result) => {
        this.dataGpph.dataSource = result;
      });
  }

  /**
   *
   * @param id
   */
  openKmpe(id: number) {
    const dialogRef = this.dialog.open(KmpeComponent, {
      width: this.width,
      data: { id },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result == 'update') {
        this.dataKmpe.dataSource.length = 0;
        this.getKmpe();
      }
    });
  }

  /**
   *
   * @returns
   */
  getKmpe() {
    if (this.dataKmpe.dataSource.length) return;

    this._pemeriksaanService
      .getPemeriksaanKmpe(this.idAnak)
      .subscribe((result) => {
        this.dataKmpe.dataSource = result;
      });
  }

  /**
   *
   * @param id
   */
  openMchat(id: number) {
    const dialogRef = this.dialog.open(MchatComponent, {
      width: this.width,
      data: { id },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result === 'update') {
        this.dataMchat.dataSource.length = 0;
      }
    });
  }

  /**
   *
   * @returns
   */
  getMchat() {
    if (this.dataMchat.dataSource.length) return;

    this._pemeriksaanService
      .getPemeriksaanMchat(this.idAnak)
      .subscribe((result) => {
        this.dataMchat.dataSource = result;
      });
  }
}

export interface PeriodicElement {
  name: string;
  position: number;
}

const ELEMENT_DATA: PeriodicElement[] = [
  {
    position: 0,
    name: 'Lingkar Kepala',
  },
  {
    position: 1,
    name: 'Status Gizi(BB/TB)',
  },
  {
    position: 2,
    name: 'Status Gizi(IMT/U)',
  },
  {
    position: 3,
    name: 'Status Gizi(TB/U)',
  },
  {
    position: 4,
    name: 'KPSP',
  },
  {
    position: 5,
    name: 'Daya Dengar',
  },
  {
    position: 6,
    name: 'Daya Lihat',
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
