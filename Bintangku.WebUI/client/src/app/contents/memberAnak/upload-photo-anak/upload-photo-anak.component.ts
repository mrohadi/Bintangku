import { HttpClient, HttpEventType } from '@angular/common/http';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-upload-photo-anak',
  templateUrl: './upload-photo-anak.component.html',
  styleUrls: ['./upload-photo-anak.component.css'],
})
export class UploadPhotoAnakComponent implements OnInit {
  baseUrl: string = environment.apiUrl;
  public progress: number;
  public message: string;
  @Output() public onUploadFinished = new EventEmitter();

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
      .post(this.baseUrl + 'upload/photo-anak', formData, {
        reportProgress: true,
        observe: 'events',
      })
      .subscribe((event) => {
        if (event.type === HttpEventType.UploadProgress)
          this.progress = Math.round((100 * event.loaded) / event.total);
        else if (event.type === HttpEventType.Response) {
          this.message = 'Upload Success!';
          this.onUploadFinished.emit(event.body);
        }
      });
  };
}
