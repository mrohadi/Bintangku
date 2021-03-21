import { Photo } from './photo';
import { RiwayatKelahiran } from './riwayatKelahiran';
import { RiwayatOrangTua } from './riwayatOrangTua';

export interface MemberAnak {
  id: number;
  namaLengkap: string;
  nik: number;
  jenisKelaminAnak: string;
  tanggalLahirAnak: Date;
  alamat: string;
  kontak: string;
  jumlahSaudara: number;
  imagePath: string;
  riwayatKelahiran: RiwayatKelahiran;
  riwayatOrangTua: RiwayatOrangTua;
  namaNakes: string;
  nakesPhoto: Photo[];
}
