import { HttpClient, HttpEventType } from '@angular/common/http';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-upload-ttd',
  templateUrl: './upload-ttd.component.html',
  styleUrls: ['./upload-ttd.component.css'],
})
export class UploadTtdComponent implements OnInit {
  baseUrl: string = environment.apiUrl;
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
      .post(this.baseUrl + 'upload/ttd', formData, {
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
