import { Component, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute } from '@angular/router';
import { FileInfo } from 'src/app/models/common/file-info';
import { Demand } from 'src/app/models/demandSection/demand';
import { NotificationService } from 'src/app/services/Shared/notification.service';
import { CompanyService } from 'src/app/services/common/company.service';
import { DemandService } from 'src/app/services/demandSection/demand.service';
import { ConfirmDialogComponent } from '../../shared/confirm-dialog/confirm-dialog.component';
import { throwError } from 'rxjs';
import { DemandFile } from 'src/app/models/demandSection/demand-file';
import { FileTypes } from 'src/app/models/common/file-types';
import { FileService } from 'src/app/services/fileSection/file.service';

@Component({
  selector: 'app-demand-details',
  templateUrl: './demand-details.component.html',
  styleUrls: ['./demand-details.component.css']
})
export class DemandDetailsComponent {
  public get dialog(): MatDialog {
    return this._dialog;
  }
  public set dialog(value: MatDialog) {
    this._dialog = value;
  }
  fileTypes : FileTypes[] = [];

  demand: Demand = new Demand;

  demandFiles : DemandFile[] = [];

  dataSource!: MatTableDataSource<any>;
  displayedColumns = ['property', 'value'];

  fileDataSource: MatTableDataSource<DemandFile> = new MatTableDataSource(this.demandFiles);
  @ViewChild(MatSort, { static: false }) sort!: MatSort;
  @ViewChild(MatPaginator, { static: false }) paginator!: MatPaginator;
  columnList: string[] = ["fileType", "description", "date", "actions"];

  constructor(
    private demandSvc: DemandService,
    private companySvc:CompanyService,
    private fileSvc:FileService,
    private activatedRoute: ActivatedRoute,
    private notificationSvc: NotificationService,
    private _dialog: MatDialog
  ) {  }


  ngOnInit(): void {
    let id: number = this.activatedRoute.snapshot.params['id'];

    this.demandSvc.getById(id).subscribe(x => {
      this.demand.title = x.title;
      this.demand.demandExpiryDate = x.demandExpiryDate;
      this.demand.companyId = x.companyId;

      this.companySvc.getById(this.demand.companyId!).subscribe(
        r => {
          this.demand.companyName = r.name;

          const demandInfo = Object.entries(this.demand)
            .filter(([property, _]) => property !== 'demandId' && property !== 'companyId')
            .map(([property, value]) => ({
              property: this.getModifiedPropertyName(property),
              value
            }));

          this.dataSource = new MatTableDataSource(demandInfo);
        },
        err => {
          this.notificationSvc.message("Failed to load Company", "DISMISS");
        }
      );
    }, err => {
      this.notificationSvc.message("Failed to load Demand !!", "DISMISS");
    });


    this.fileSvc.get()
    .subscribe(x => {
      this.fileTypes = x;

      this.demandSvc.getFiles()
      .subscribe(x => {
        this.demandFiles = x;

        x.forEach(df => {
          console.log(df);
          console.log(df.date);
          console.log(df.FileTypeId);
          // let id = df.FileTypeId ?? 0;
          // df.FileType = this.getFileTypeName(id);
        });

        this.fileDataSource.data = this.demandFiles;
        this.fileDataSource.paginator = this.paginator;
        this.fileDataSource.sort = this.sort;
      }, err => {
        this.notificationSvc.message("Failed to load Demand data", "DISMISS");
      });
    }, err => {
      this.notificationSvc.message("Failed to load File Type data!!!", "DISMISS");
    });

  }

  getModifiedPropertyName(property: string): string {
    if (property === 'title') {
      return 'Demand';
    } else if (property === 'demandExpiryDate') {
      return 'Expiry Date';
    } else if (property === 'companyName') {
      return 'Company';
    }
    else {
      return property;
    }
  }

  getFileTypeName(id: number) {
    console.log(id);
    let c = this.fileTypes.find(x => x.fileTypeId == id);
    console.log(c?.name);
    return c ? c.name : '';
  }

  confirmDelete(data: Demand) {
    this.dialog.open(ConfirmDialogComponent, {
      width: '450px',
      enterAnimationDuration: '800ms'
    }).afterClosed()
      .subscribe(result => {
        if (result) {
          this.demandSvc.delete(data)
            .subscribe({
              next: r => {
                this.notificationSvc.message('File removed', 'DISMISS');
                this.dataSource.data = this.dataSource.data.filter(c => c.demandId != data.demandId);
              },
              error: err => {
                this.notificationSvc.message('Failed to delete file', 'DISMISS');
                throwError(() => err);
              }
            })
        }
      })
  }

}
