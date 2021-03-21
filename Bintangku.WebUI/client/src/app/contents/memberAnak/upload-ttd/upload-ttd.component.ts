import { HttpClient, HttpEventType } from '@angular/common/http';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-upload-ttd',
  templateUrl: './upload-ttd.component.html',
  styleUrls: ['./upload-ttd.component.css'],
})
export class UploadTtdComponent implements OnInit {
  public progress: number;
  public message: string;
  @Output() public onUploadTtdFinished = new EventEmitter();

  constructor(private http: HttpClient) {}

  ngOnInit(): void {}

  public uploadFile = (files) => {
    if (files.length === 0) {
      return;
    }

    let fileToUpload = <File>files[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);

    this.http
      .post('https://localhost:5001/api/uploadttd', formData, {
        reportProgress: true,
        observe: 'events',
      })
      .subscribe((event) => {
        if (event.type === HttpEventType.UploadProgress) {
          this.progress = Math.round((100 * event.loaded) / event.total);
        } else if (event.type === HttpEventType.Response) {
          this.message = 'Upload Success!';
          this.onUploadTtdFinished.emit(event.body);
        }
      });
  };
}
