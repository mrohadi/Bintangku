import { Photo } from './photo';
import { RiwayatOrangTua } from './riwayatOrangTua';

export interface MemberAnak {
  dataAnakId: number;
  namaLengkap: string;
  nik: number;
  jenisKelaminAnak: string;
  tanggalLahirAnak: Date;
  alamat: string;
  kontak: string;
  jumlahSaudara: number;
  riwayatOrangTua: RiwayatOrangTua;
  imagePath: string;
  namaNakes: string;
  nakesPhoto: Photo[];
}
