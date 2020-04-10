import { MatPaginatorIntl } from '@angular/material';

const vietnameseRangeLabel = (page: number, pageSize: number, length: number) => {
  if (length == 0 || pageSize == 0) { return `Không có bản ghi nào`; }
  
  length = Math.max(length, 0);

  const startIndex = page * pageSize;

  // If the start index exceeds the list length, do not try and fix the end index to the end.
  const endIndex = startIndex < length ?
      Math.min(startIndex + pageSize, length) :
      startIndex + pageSize;

  return `Hiển thị bản ghi ${startIndex + 1} - ${endIndex} trên tổng số ${length}`;
}


export function getVietnamesePaginatorIntl() {
  const paginatorIntl = new MatPaginatorIntl();
  
  paginatorIntl.itemsPerPageLabel = 'Số lượng bản ghi mỗi trang:';
  paginatorIntl.nextPageLabel = 'Sau';
  paginatorIntl.previousPageLabel = 'Trước';
  paginatorIntl.getRangeLabel = vietnameseRangeLabel;
  
  return paginatorIntl;
}